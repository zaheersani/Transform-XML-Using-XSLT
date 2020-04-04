# Transform XML Using XSLT/XSL

This is a .Net Console Application which works as a CommandLine Tool.

It uses XSLT to transform XML documents into other formats (like transforming XML into HTML, CSV, Text etc).

# Installation

Download repository and open .sln file in Visual Studio 2013 or above

It requires at least .Net Framework version 4.6.1

# Usage

CommandLine tool takes 3 arguments:
1. XML File (with file extension. i.e. `xml`)
2. XSLT/XSL File (with file extension. i.e. `xsl`)
3. Output File (this is your desired output and can be of any extions type, html, csv, txt etc)

_Note: Source code includes `SampleXML.xml` and `SampleXSL.xsl` files under 'Samples' directory_

Once source code is compiled successfully, browse to binary output directory through `CMD` and run the program like this:

```bash
C:\ExeFileDirectory>TransformXMLUsingXSL.exe SampleXML.xml SampleXSL.xsl Output.html
```

## Sample Input XML

```xml
<?xml version="1.0" encoding="UTF-8"?>
<catalog>
  <cd>
    <title>Empire Burlesque</title>
    <artist>Bob Dylan</artist>
    <country>USA</country>
    <company>Columbia</company>
    <price>10.90</price>
    <year>1985</year>
  </cd>
  <cd>
    <title>Hide your heart</title>
    <artist>Bonnie Tyler</artist>
    <country>UK</country>
    <company>CBS Records</company>
    <price>9.90</price>
    <year>1988</year>
  </cd>
  <cd>
    <title>Greatest Hits</title>
    <artist>Dolly Parton</artist>
    <country>USA</country>
    <company>RCA</company>
    <price>9.90</price>
    <year>1982</year>
  </cd>
</catalog>
```

## Sample Input XSLT/XSL

```xsl
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h2>My CD Collection</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th style="text-align:left">Title</th>
            <th style="text-align:left">Artist</th>
            <th style="text-align:left">Year</th>
          </tr>
          <xsl:for-each select="catalog/cd">
            <tr>
              <td>
                <xsl:value-of select="title"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
```

## Output (Let's say `Output.html`)

![Output.html](https://github.com/zaheersani/Transform-XML-Using-XSLT/blob/master/XSLOutputBugFix/Samples/SampleOutput.png)

