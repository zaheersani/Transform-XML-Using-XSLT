using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace XSLOutputBugFix
{
    class Program
    {
        private static string sourceFile = "SampleXML.xml";
        private static string stylesheet = "SampleXSL.xsl";
        private static string outputFile = "SampleOutput.html";

        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Program takes three arguments in sequence: xmlFileName.xml xslFileName.xsl outputFileName");
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
            }
            else if (args.Length == 3)
            {
                // Verify the file extensions. First argument should be XML and 2nd should be XSL
                if(args[0].EndsWith(".xml") && args[1].EndsWith(".xsl"))
                {
                    sourceFile = args[0];
                    stylesheet = args[1];
                    outputFile = args[2];
                } else {
                    Console.WriteLine("Program takes three arguments in sequence: xmlFileName.xml xslFileName.xsl outputFileName");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                    return;
                }
                string exceptionSource = "";
                string exceptionMessage = "";
                try
                {
                    // Enable XSLT debugging.
                    XslCompiledTransform xslt = new XslCompiledTransform(true);

                    // Compile the style sheet.
                    xslt.Load(stylesheet);

                    // Execute the XSLT transform.
                    FileStream outputStream = new FileStream(outputFile, FileMode.Create);
                    xslt.Transform(sourceFile, null, outputStream);

                    Console.WriteLine("'{0}' Output file has been generated!", outputFile);
                }
                catch(XsltException xslExc)
                {
                    exceptionSource = xslExc.SourceUri;
                    exceptionMessage = xslExc.Message;
                }
                catch(XmlException xmlExc)
                {
                    exceptionSource = xmlExc.SourceUri;
                    exceptionMessage = xmlExc.Message;
                }
                catch (Exception ex)
                {
                    exceptionSource = ex.Source;
                    exceptionMessage = ex.Message;
                }
                finally
                {
                    // In case exception raised
                    if (exceptionMessage.Length > 0 || exceptionSource.Length > 0)
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Something went wrong! Here is the error:");
                        Console.WriteLine("Source: " + exceptionSource);
                        Console.WriteLine("Error Message: " + exceptionMessage);
                        Console.WriteLine("-------------------------------------------------");
                    }
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
            }
        }
    }
}