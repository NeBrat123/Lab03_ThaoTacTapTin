<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/book"><html><body><h2><xsl:value-of select="title" /></h2><p><xsl:value-of select="author" /></p></body></html></xsl:template>
</xsl:stylesheet>
