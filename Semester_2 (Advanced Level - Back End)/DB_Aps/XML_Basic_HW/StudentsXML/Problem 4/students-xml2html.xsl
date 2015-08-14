<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h1>Students</h1>
  <table bgcolor="#E0E0E0" cellspacing="1">
    <tr bgcolor="#EEEEEE">
      <td><b>Name</b></td>
      <td><b>Gender</b></td>
      <td><b>Birt date</b></td>
      <td><b>Phone number</b></td>
      <td><b>Email</b></td>
      <td><b>University</b></td>
      <td><b>Speciality</b></td>
      <td><b>Faculty number</b></td>
      <td><b>Exams</b></td>
    </tr>
	<xsl:for-each select="/students/student">
      <tr bgcolor="white">
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="gender"/></td>
        <td><xsl:value-of select="birth-date"/></td>
        <td><xsl:value-of select="phone-number"/></td>
        <td><xsl:value-of select="email"/></td>
        <td><xsl:value-of select="university"/></td>
        <td><xsl:value-of select="speciality"/></td>
        <td><xsl:value-of select="faculty-number"/></td>
        <td>
          <table bgcolor="#E0E0E0" cellspacing="1">
            <tr bgcolor="#EEEEEE">
              <td><b>Exam name</b></td>
              <td><b>Date taken</b></td>
              <td><b>Grade</b></td>         
            </tr>
            
            <xsl:for-each select="./exams/exam">
              <tr bgcolor="white">
                <td><xsl:value-of select="exam-name"/></td>
                <td><xsl:value-of select="date-taken"/></td>
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