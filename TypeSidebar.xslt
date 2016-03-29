<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="text" indent="no"/>
  <xsl:template match="/" xml:space="default">
    <xsl:apply-templates mode="header" select="/members/type"/>
    <xsl:apply-templates mode="body" select="/members"/>
  </xsl:template>

  <!--HEADER-->
  <xsl:template match="type" mode="header">
    <xsl:text>#summary Sidebar for </xsl:text>
    <xsl:value-of select="@typeName"/>
    <xsl:text>type
#labels WikiDoc,Sidebar
</xsl:text>
  </xsl:template>

  <!--BODY-->
  <xsl:template match="members" mode="body">
    <xsl:if test="member[@memberType='Field']">
      <xsl:text>  * [#Fields Fields]
</xsl:text>
      <xsl:apply-templates mode="field" select="member[@memberType='Field']"/>
    </xsl:if>
    <xsl:if test="member[@memberType='Property']">
      <xsl:text>  * [#Properties Properties]
</xsl:text>
      <xsl:apply-templates mode="property" select="member[@memberType='Property']"/>
    </xsl:if>
    <xsl:if test="member[@memberType='Method']">
      <xsl:text>  * [#Methods Methods]
</xsl:text>
      <xsl:apply-templates mode="method" select="member[@memberType='Method']"/>
    </xsl:if>
    <xsl:if test="member[@memberType='Event']">
      <xsl:text>  * [#Events Events]
</xsl:text>
      <xsl:apply-templates mode="event" select="member[@memberType='Event']"/>
    </xsl:if>
  </xsl:template>

  <xsl:template match="member" mode="field">
    <xsl:text>    * [</xsl:text>
    <xsl:value-of select="@anchor"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>]
</xsl:text>
  </xsl:template>

  <xsl:template match="member" mode="property">
    <xsl:text>    * [</xsl:text>
    <xsl:value-of select="@anchor"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>]
</xsl:text>
  </xsl:template>

  <xsl:template match="member" mode="method">
    <xsl:text>    * [</xsl:text>
    <xsl:value-of select="@anchor"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>]
</xsl:text>
  </xsl:template>

  <xsl:template match="member" mode="event">
    <xsl:text>    * [</xsl:text>
    <xsl:value-of select="@anchor"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>]
</xsl:text>
  </xsl:template>
</xsl:stylesheet>
