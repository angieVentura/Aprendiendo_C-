using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace JuegoPinguinos
{
    public class RopePoint
    {
        public Vector2 pos;
        public Vector2 oldPos;
        public Vector2 velocity;
        public bool isFixed;
        public float distanceToNextPoint;
        public float mass;
        public float damping;
        public RopePoint prev;
        public RopePoint next;

        public static void Integrate(RopePoint point, Vector2 gravity, float dt, float previousFrameDt)
        {
            point.velocity = Vector2.Subtract(point.pos, point.oldPos);
            point.oldPos = point.pos;

            float timeCorrection = previousFrameDt != 0.0f ? dt / previousFrameDt : 0.0f;

            Vector2 accel = Vector2.Add(gravity, new Vector2(0, point.mass));

            float velCoef = timeCorrection * point.damping;
            float accelCoef = dt * dt;

            point.pos.X += point.velocity.X * velCoef + accel.X * accelCoef;
            point.pos.Y += point.velocity.Y * velCoef + accel.Y * accelCoef;
        }

        public static void Constrain(RopePoint point)
        {
            if (point.next != null)
            {
                Vector2 delta = Vector2.Subtract(point.next.pos, point.pos);
                float len = delta.Length();
                float diff = len - point.distanceToNextPoint;
                Vector2 normal = Vector2.Normalize(delta);

                if (!point.isFixed)
                {
                    point.pos += normal * diff * 0.25f;
                }

                if (!point.next.isFixed)
                {
                    point.next.pos -= normal * diff * 0.25f;
                }
            }
            if (point.prev != null)
            {
                Vector2 delta = Vector2.Subtract(point.prev.pos, point.pos);
                float len = delta.Length();
                float diff = len - point.distanceToNextPoint;
                Vector2 normal = Vector2.Normalize(delta);

                if (!point.isFixed)
                {
                    point.pos += normal * diff * 0.25f;
                }

                if (!point.prev.isFixed)
                {
                    point.prev.pos -= normal * diff * 0.25f;
                }
            }
        }

        public RopePoint(Vector2 initialPos, float distanceToNextPoint)
        {
            pos = initialPos;
            this.distanceToNextPoint = distanceToNextPoint;
            isFixed = false;
            oldPos = initialPos;
            velocity = Vector2.Zero;
            mass = 1.0f;
            damping = 1.0f;
            prev = null;
            next = null;
        }
    }

    public class Rope
    {
        public List<RopePoint> _points;
        private float _prevDelta;
        private int _solverIterations;
        private Texture2D _pixelTexture;
        private GraphicsDevice _graphicsDevice;
        public static int NumPointsGenerated { get; private set; }
        public static int NumAct { get; private set; }

        public Rope(List<RopePoint> points, int solverIterations, Texture2D pixelTexture, GraphicsDevice graphicsDevice)
        {
            _points = points;
            _solverIterations = solverIterations;
            _prevDelta = 0;
            _pixelTexture = pixelTexture;
            _graphicsDevice = graphicsDevice;
        }

        public void SetPoint(List<RopePoint> newPoints)
        {
            this._points = newPoints;
        }

        public RopePoint GetPoint(int index)
        {
            return _points[index];
        }

        public void Update(Vector2 gravity, float dt, Vector2 newStart, Vector2 newEnd)
        {
            // Actualizar las posiciones de Start y End
            _points[0].pos = newStart;
            _points[_points.Count - 1].pos = newEnd;

            // Actualizar la cuerda según las nuevas posiciones de Start y End
            for (int i = 1; i < _points.Count - 1; i++)
            {
                RopePoint.Integrate(_points[i], gravity, dt, _prevDelta);
            }

            for (int iteration = 0; iteration < _solverIterations; iteration++)
            {
                for (int i = 1; i < _points.Count - 1; i++)
                {
                    RopePoint.Constrain(_points[i]);
                }
            }

            _prevDelta = dt;
        }

        public static List<RopePoint> Generate(Vector2 start, Vector2 end, float resolution, float mass, float damping)
        {
            Vector2 delta = end - start;
            float len = delta.Length();

            List<RopePoint> points = new List<RopePoint>();
            float pointsLen = len / resolution;

            for (int i = 0; i < pointsLen; i++)
            {
                float percentage = i / (pointsLen - 1);

                float lerpX = MathHelper.Lerp(start.X, end.X, percentage);
                float lerpY = MathHelper.Lerp(start.Y, end.Y, percentage);

                RopePoint point = new RopePoint(new Vector2(lerpX, lerpY), resolution);
                point.mass = mass;
                point.damping = damping;
                NumPointsGenerated++;
                points.Add(point);
            }

            for (int i = 0; i < points.Count; i++)
            {
                RopePoint prev = i != 0 ? points[i - 1] : null;
                RopePoint curr = points[i];
                RopePoint next = i != points.Count - 1 ? points[i + 1] : null;

                curr.prev = prev;
                curr.next = next;
            }

            points[0].isFixed = points[points.Count - 1].isFixed = true;

            return points;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _points.Count - 1; i++)
            {
                // if (i % 18 == 0)
                //{
                Vector2 direction = _points[i + 1].pos - _points[i].pos;
                float rotation = (float)Math.Atan2(direction.Y, direction.X);

                float distance = direction.Length();

                spriteBatch.Draw(_pixelTexture, _points[i].pos, null, Color.White, rotation, Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0);
                //}

            }
        }
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rope _rope;
        private Texture2D _pixelTexture;
        private Texture2D _pinguino1;
        private Texture2D _pinguino2;
        private SpriteFont _font;
        private int _numPointsDisplayed;
        public Vector2 pinguino1, pinguino2;
        Vector2 start;
        Vector2 end;
        float resolution;
        float mass;
        float damping;
        int solverIterations;
        bool movDer, movIzq;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            this._graphics.PreferredBackBufferWidth = 800;
            this._graphics.PreferredBackBufferHeight = 600;
            _numPointsDisplayed = 0;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _pixelTexture = Content.Load<Texture2D>("punto");
            _pinguino1 = Content.Load<Texture2D>("per");
            _pinguino2 = Content.Load<Texture2D>("per");
            _font = Content.Load<SpriteFont>("arial");

            start = new Vector2(250, 100);
            end = new Vector2(400, 100);
            resolution = 2f;
            mass = 0.88f;
            damping = 0.95f;
            solverIterations = 500;
            pinguino1 = new Vector2(600, 20);
            pinguino2 = new Vector2(100, 20);
            movDer = true;
            movIzq = true;


            List<RopePoint> points = Rope.Generate(start, end, resolution, mass, damping);
            _rope = new Rope(points, solverIterations, _pixelTexture, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Down) && Vector2.Distance(new Vector2(start.X, start.Y + 1), end) < 201)
            {
                start.Y++;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) && Vector2.Distance(new Vector2(start.X + 1, start.Y), end) < 201)
            {
                start.X++;
            }
            else if (keyboardState.IsKeyDown(Keys.Left) && Vector2.Distance(new Vector2(start.X - 1, start.Y), end) < 201)
            {
                start.X--;
            }
            else if (keyboardState.IsKeyDown(Keys.Up) && Vector2.Distance(new Vector2(start.X, start.Y - 1), end) < 201)
            {
                start.Y--;
            }

            if (keyboardState.IsKeyDown(Keys.A) && Vector2.Distance(new Vector2(end.X - 1, end.Y), start) < 201)
            {
                end.X--;
            }
            else if (keyboardState.IsKeyDown(Keys.D) && Vector2.Distance(new Vector2(end.X + 1, end.Y), start) < 201)
            {
                end.X++;
            }
            else if (keyboardState.IsKeyDown(Keys.W) && Vector2.Distance(new Vector2(end.X, end.Y - 1), start) < 201)
            {
                end.Y--;
            }
            else if (keyboardState.IsKeyDown(Keys.S) && Vector2.Distance(new Vector2(end.X, end.Y + 1), start) < 201)
            {
                end.Y++;
            }

            _rope.Update(new Vector2(0, 3000), (float)gameTime.ElapsedGameTime.TotalSeconds, start, end);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _rope.Draw(_spriteBatch);
            _spriteBatch.DrawString(_font, $"Points: {Rope.NumPointsGenerated}\n Act: {Rope.NumAct}\n DisA:{Vector2.Distance(start, end)}\nDisB{Vector2.Distance(end, start)}", new Vector2(10, 10), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}
