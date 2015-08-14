<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h1>Albums</h1>
  <table bgcolor="#E0E0E0" cellspacing="1">
    <tr bgcolor="#EEEEEE">
      <td><b>Name</b></td>
      <td><b>Artist</b></td>
      <td><b>Year</b></td>
      <td><b>Producer</b></td>
      <td><b>Price</b></td>
      <td><b>Songs</b></td>
    </tr>
	<xsl:for-each select="/catalog/album">
      <tr bgcolor="white">
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="artist"/></td>
        <td><xsl:value-of select="year"/></td>
        <td><xsl:value-of select="producer"/></td>
        <td><xsl:value-of select="price"/></td>
        <td><xsl:value-of select="university"/></td>
        <td><xsl:value-of select="speciality"/></td>
        <td><xsl:value-of select="faculty-number"/></td>
        <td>
          <table bgcolor="#E0E0E0" cellspacing="1">
            <tr bgcolor="#EEEEEE">
              <td><b>Title</b></td>
              <td><b>Duration</b></td>        
            </tr>
            
            <xsl:for-each select="./songs/song">
              <tr bgcolor="white">
                <td><xsl:value-of select="title"/></td>
                <td><xsl:value-of select="duration"/></td>
                <td><xsl:value-of select="grade"/></td>
              </tr>
            </xsl:for-each>             
          </table>
        </td>
      </tr>
	</xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>