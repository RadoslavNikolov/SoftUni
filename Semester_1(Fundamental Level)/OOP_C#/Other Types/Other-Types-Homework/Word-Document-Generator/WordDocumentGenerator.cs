using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Document_Generator
{
    using System.Drawing;
    using System.IO;
    using System.Security.Claims;
    using System.Text.RegularExpressions;
    using Novacode;

    class WordDocumentGenerator
    {
        static void Main(string[] args)
        {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string docName = "GeneratedWordDocument.docx";
            string inputFileName = "text.txt";
            string imageName = "rpg-game.png";

            using (DocX document = DocX.Create(projectDir + Path.DirectorySeparatorChar + docName))
            {
                using (StreamReader reader = new StreamReader(projectDir + Path.DirectorySeparatorChar + inputFileName))
                {

                    var paragraph = document.InsertParagraph();
                    paragraph.Alignment = Alignment.center;
                    paragraph.Append(reader.ReadLine()).FontSize(26).Bold();

                    //Picture
                    var img = document.AddImage(projectDir + Path.DirectorySeparatorChar + imageName);

                    paragraph = document.InsertParagraph();

                    Picture picture = img.CreatePicture();
                    picture.Width = picture.Width/3;
                    picture.Height = picture.Height/3;

                    paragraph.InsertPicture(picture);

                    for (int i = 0; i < 3; i++)
                    {
                        paragraph = document.InsertParagraph();
                        paragraph.Append(reader.ReadLine());
                        paragraph.ReplaceText("role playing game", "role playing game", false, RegexOptions.None, new Formatting() {Bold = true});
                        paragraph.ReplaceText("grand prize!", "grand prize!", false, RegexOptions.None, new Formatting() { UnderlineStyle = UnderlineStyle.singleLine });
                    }

                    //bullets
                    var list = document.AddList(listType: ListItemType.Bulleted);
                    for (int i = 0; i < 3; i++)
                    {
                        document.AddListItem(list, reader.ReadLine());
                    }

                    //Empty line
                    document.InsertParagraph(reader.ReadLine());

                    //table
                    var table = document.AddTable(4, 3);
                    table.Alignment = Alignment.center;
                    table.Design = TableDesign.ColorfulGrid;

                    for (int i = 0; i < 3; i++)
                    {
                        table.Rows[0].Cells[i].FillColor = Color.Beige;
                    }

                    for (int row = 0; row < 4; row++)
                    {
                        string[] rowContent = reader.ReadLine().Split(new char[] {' ', '\t'});
                        for (int col = 0; col < rowContent.Length; col++)
                        {
                            table.Rows[row].Cells[col].Paragraphs.First().Append(rowContent[col]).Alignment = Alignment.center;
                        }
                    }

                    document.InsertTable(table);

                    //Empty line
                    document.InsertParagraph(reader.ReadLine());

                    //Last two lines of text
                    paragraph = document.InsertParagraph();
                    paragraph.Append(reader.ReadLine()).Alignment = Alignment.center;
                    paragraph.ReplaceText("SPECTACULAR", "SPECTACULAR", false, RegexOptions.None, new Formatting() { Bold = true });

                    paragraph = document.InsertParagraph();
                    paragraph.Append(reader.ReadLine())
                        .FontSize(20)
                        .Font(new FontFamily("Arial"))
                        .UnderlineStyle(UnderlineStyle.singleLine)
                        .Alignment = Alignment.center;
                }

                document.Save();

            }

        }
    }
}
