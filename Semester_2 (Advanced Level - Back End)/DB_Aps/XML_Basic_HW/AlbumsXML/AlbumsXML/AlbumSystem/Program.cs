using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumSystem
{
    using System.Net;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string mainFileXPaht = "../../../catalog.xml";
            var doc = new XmlDocument();
            doc.Load(mainFileXPaht);
            

            if (doc.DocumentElement != null)
            {
                //Problem2
                //GetAlbumNames(doc);

                //Problem3
                //GetArtistNames(doc);

                //Problem4
                //GetNumOfAlbumsPerArtist(doc);

                //Problem5
                //GetNumOfAlbumsPerArtistUsingXPath(doc);

                //Problem6                
                ////Copy catalog.xml file into cheap-albums-catalog.xml
                //string newFileXPath = "../../../cheap-albums-catalog.xml";
                //DeepCopyFile(mainFileXPaht, newFileXPath);
                //DeleteAlbumsUsingDOMParser(newFileXPath);

                //Problem7
                //GetOldAlbums(doc);

                //Problem8
                //GetOldAlbumsUsingLINQ(mainFileXPaht);
            }
        }


        //Problem 8.	LINQ to XML: Old Albums
        private static void GetOldAlbumsUsingLINQ(string mainFileXPaht)
        {
            XDocument linqDoc = XDocument.Load(mainFileXPaht);
            var albums =
                from a in linqDoc.Descendants("album")
                where Convert.ToInt32(a.Element("year").Value) <= (DateTime.Now.Year - 5)
                select new
                {
                    Name = a.Element("name").Value,
                    Price = a.Element("price").Value
                };

            Console.WriteLine("Found {0} albums: ", albums.Count());
            foreach (var album in albums)
            {
                Console.WriteLine("Title: {0} , Price: {1}", album.Name, album.Price);
            }
        }


        //Problem 7.	DOM Parser and XPath: Old Albums
        private static void GetOldAlbums(XmlDocument doc)
        {
            int searchingYear = DateTime.Now.Year - 5;
            string xPathQuery = "/catalog/album[year <= " + searchingYear + "]";
            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            if (albums != null)
            {
                foreach (XmlNode album in albums)
                {
                    Console.WriteLine("Album: {0}, Price: {1}", album["name"].InnerText, album["price"].InnerText);
                }
            }
        }

        private static void DeleteAlbumsUsingDOMParser(string newFileXPath)
        {
            var newDoc = new XmlDocument();
            newDoc.Load(newFileXPath);
            if (newDoc.DocumentElement != null)
            {
                var rootNode = newDoc.DocumentElement.ChildNodes;
                int count = 0;
                foreach (XmlNode node in rootNode)
                {
                    var price = node["price"].InnerText;
                    Console.WriteLine(price);

                    if (Convert.ToInt32(price) < 100)
                    {
                        if (node.ParentNode != null)
                        {
                            node.ParentNode.RemoveChild(node);
                            count++;
                        }
                    }
                }

                Console.WriteLine("{0} Albums have been deleted!", count);
                newDoc.Save(newFileXPath);
                Console.WriteLine("Document has been saved as: {0}", newFileXPath);
            }
        }


        private static void DeepCopyFile(string mainFileXPaht, string newFileXPath)
        {
            WebClient client = new WebClient();
            client.DownloadFile(mainFileXPaht, newFileXPath);
        }

        //Problem 5.	XPath: Extract Artists and Number of Albums
        private static void GetNumOfAlbumsPerArtistUsingXPath(XmlDocument doc)
        {
            var albums = doc.SelectNodes("/catalog/album");
            var artistsAlbums = new Dictionary<string, int>();

            foreach (XmlElement album in albums)
            {
                var artist = album["artist"].InnerText;

                if (!artistsAlbums.ContainsKey(artist))
                {
                    artistsAlbums[artist] = 1;
                }
                else
                {
                    artistsAlbums[artist] += 1;
                }
            }

            foreach (var artist in artistsAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums count: {1}", artist.Key, artist.Value);
            }
        }


        //Problem 4.	DOM Parser: Extract Artists and Number of Albums
        private static void GetNumOfAlbumsPerArtist(XmlDocument doc)
        {
            var rootNode = doc.DocumentElement.ChildNodes;
            var artistsAlbums = new Dictionary<string, int>();
            foreach (XmlNode node in rootNode)
            {
                var artist = node["artist"].InnerText;

                if (!artistsAlbums.ContainsKey(artist))
                {
                    artistsAlbums[artist] = 1;
                }
                else
                {
                    artistsAlbums[artist] += 1;
                }
            }

            foreach (var artist in artistsAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums count: {1}", artist.Key, artist.Value);
            }
        }


        //Problem 3.	DOM Parser: Extract All Artists Alphabetically
        private static void GetArtistNames(XmlDocument doc)
        {
            var rootNode = doc.DocumentElement.ChildNodes;
            List<String> artists = new List<string>();

            foreach (XmlNode node in rootNode)
            {
                artists.Add(node["artist"].InnerText);
            }

            artists.Sort();
            artists.ForEach(a => Console.WriteLine("Artist name: {0}", a));
        }


        //Problem 2.	DOM Parser: Extract Album Names
        private static void GetAlbumNames(XmlDocument doc)
        {
            var rootNode = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in rootNode)
            {
                Console.WriteLine("Album name: {0}", node["name"].InnerText);
            }
        }



    }
}
