using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace MotorGraficoPinguino
{
    internal class GameObjects
    {
        private static Texture2D map = Globals.Content.Load<Texture2D>("pinguinosMap");
        private Texture2D tiles = Globals.Content.Load<Texture2D>("plataformas");
        private Texture2D _collider = Globals.Content.Load<Texture2D>("White");
        private List<List<Color[,]>> pixelDataList;
        private int height = 32;
        private int width = 32;
        public List<GameObject> objects;
        public string tileSize;
        private Color skipColor = new Color(255, 0, 202, 255);
        private int count = 0;
        private List<Color> elementos = new List<Color> { Color.White, Color.Red, Color.Blue, Color.Orange, Color.Gray, Color.Green};
        private List<Animationes> _animationes;
        private const int SIZE_COLLIDER = 32;

        public GameObjects()
        {
            this.pixelDataList = GeneratePixelDataList(tiles);
            this.objects = CreateGamesObject();
            tileSize = $"mapWidth: {map.Width}\nmapHeight: {map.Height}\ntilesWidth: {tiles.Width}\ntilesHeight: {tiles.Height}\ncollider: ({_collider.Width}, {_collider.Height})\n Tiles: {objects.Count}\n CountOmit: {count}\n ColorOmit: {skipColor}";
        }

        public void LoadContent()
        {
            _animationes = new List<Animationes> {

                new Animationes("D", new Animation(_collider, SIZE_COLLIDER, SIZE_COLLIDER, 1, 1000, 0, 0, false)),
            };
        }

        private List<List<Color[,]>> GeneratePixelDataList(Texture2D tiles)
        {
            List<List<Color[,]>> dataLists = new List<List<Color[,]>>();

            int cantTilesX = tiles.Width / width;
            int cantTilesY = tiles.Height / height;

            for (int y = 0; y < cantTilesY; y++)
            {
                List<Color[,]> dataList = new List<Color[,]>();
                for (int x = 0; x < cantTilesX; x++)
                {
                    Color[,] tileData = PixelData(new Rectangle(x * 32, y * 32, width, height), tiles);

                    if (tileData[0, 0] != skipColor) dataList.Add(tileData);
                }
                dataLists.Add(dataList);
            }

            return dataLists;
        }

        //crear compracion toda lol
        private List<GameObject> CreateGamesObject()
        {

            List<GameObject> objects = new List<GameObject>();

            int cantTilesX = map.Width / width;
            int cantTilesY = map.Height / height;

            for (int y = 0; y < cantTilesY; y++)
            {
                for (int x = 0; x < cantTilesX; x++)
                {
                    Color[,] mapTileData = PixelData(new Rectangle(x * 32, y * 32, width, height), map);

                    if (mapTileData[0, 0] != skipColor)
                    {
                        for (int i = 0; i < pixelDataList.Count - 1; i++)
                        {
                            foreach (Color[,] pixelData in pixelDataList[i])
                            {
                                if (ArePixelDataEqual(mapTileData, pixelData))
                                {

                                    Texture2D tile = _collider;
                                    int frameCount = 1;
                                    int row = 0;
                                    int column = 0;
                                    float frameTime = 1000000;
                                    bool left = false;
                                    string name = "Collider";
                                    Color color = elementos[i];


                                    /* if (GetUniformPixelColor(pixelData) != null)
                                     {
                                         //mecanimos para actuar segun el color 

                                     }*/

                                    Animation animation = new Animation(tile, width, height, frameCount, frameTime, row, column, left);
                                    objects.Add(new GameObject(new Vector2(x * 32, y * 32), name, color, animation, width, height));
                                    break;
                                }

                            }
                        }
                    }
                    else
                    {
                        count++;
                    }

                }
            }

            return objects;
        }

        private Color? GetUniformPixelColor(Color[,] pixelData)
        {
            Color firstPixelColor = pixelData[0, 0];

            for (int x = 0; x < pixelData.GetLength(0); x++)
            {
                for (int y = 0; y < pixelData.GetLength(1); y++)
                {
                    if (pixelData[x, y] != firstPixelColor)
                    {
                        return null;
                    }
                }
            }
            return firstPixelColor;
        }

        private bool ArePixelDataEqual(Color[,] data1, Color[,] data2)
        {
            if (data1.GetLength(0) != data2.GetLength(0) || data1.GetLength(1) != data2.GetLength(1))
            {
                return false;
            }

            for (int x = 0; x < data1.GetLength(0); x++)
            {
                for (int y = 0; y < data1.GetLength(1); y++)
                {
                    if (data1[x, y] != data2[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private Color[,] PixelData(Rectangle sourceRectangle, Texture2D texture)
        {

            Texture2D tileTexture = new Texture2D(texture.GraphicsDevice, width, height);
            Color[] data = new Color[width * height];
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            tileTexture.SetData(data);

            Color[,] pixelData = GetPixelData(tileTexture);

            return pixelData;
        }

        private Color[,] GetPixelData(Texture2D texture)
        {
            Color[] colors1D = new Color[texture.Width * texture.Height];
            texture.GetData(colors1D);
            Color[,] colors2D = new Color[texture.Width, texture.Height];

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    colors2D[x, y] = colors1D[x + y * texture.Width];
                }
            }

            return colors2D;
        }

        public static List<Rectangle> GetNearestColliders(Rectangle bounds)
        {
            int topTile = (int)Math.Floor((float)bounds.Top / SIZE_COLLIDER);
            int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / SIZE_COLLIDER) - 1;
            int leftTile = (int)Math.Floor((float)bounds.Left / SIZE_COLLIDER);
            int rightTile = (int)Math.Ceiling((float)bounds.Right / SIZE_COLLIDER) - 1;

            topTile = MathHelper.Clamp(topTile, 0, map.Width/ SIZE_COLLIDER);
            bottomTile = MathHelper.Clamp(bottomTile, 0, map.Width / SIZE_COLLIDER);
            leftTile = MathHelper.Clamp(leftTile, 0, map.Height / SIZE_COLLIDER);
            rightTile = MathHelper.Clamp(rightTile, 0, map.Height / SIZE_COLLIDER);

            List<Rectangle> result = new List<Rectangle>();

            for (int x = topTile; x <= bottomTile; x++)
            {
                for (int y = leftTile; y <= rightTile; y++)
                {
                    //esta que le dice que tiene bloques en todas partes
                    result.Add(new Rectangle(x * SIZE_COLLIDER, y * SIZE_COLLIDER, SIZE_COLLIDER, SIZE_COLLIDER));
                }
            }

            return result;
        }

        public void Draw()
        {
            foreach (var gameObject in objects)
            {
                gameObject.animation.Draw(Globals.Spritebatch, gameObject.pos, gameObject.color, 1f);
            }
        }

    }
}
