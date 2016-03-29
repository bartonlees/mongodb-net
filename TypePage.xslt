<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <!--ROOT-->
  <xsl:output method="text" indent="no"/>
  <xsl:template match="/">
    <xsl:apply-templates select="/members"/>
  </xsl:template>

  <!--DOCUMENT-->
  <xsl:template match="members">
    <xsl:text>#summary API documentation for the</xsl:text>
    <xsl:value-of select="type/@caption"/>
    <xsl:text> type
#labels WikiDoc,Type
#sidebar </xsl:text>
    <xsl:value-of select="type/@sidebar"/>
    <xsl:text>
----
_MongoDB.Driver API_
= `</xsl:text>
    <xsl:apply-templates select="type" mode="summaryDecl"/>
    <xsl:text>` =
</xsl:text>
    <xsl:if test="type/summary">
      <xsl:text>== Summary ==
</xsl:text>
      <xsl:value-of select="normalize-space(type/summary)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:if test="type/remarks">
      <xsl:text>== Remarks ==
</xsl:text>
      <xsl:value-of select="normalize-space(type/remarks)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:apply-templates mode="members" select="type"/>
  </xsl:template>

  <!--SUMMARY-->
  <xsl:template mode="summaryDecl" match="type[@isEnum='true']" >
    <xsl:text>public enum </xsl:text>
    <xsl:value-of select="@caption"/>
  </xsl:template>
  <xsl:template mode="summaryDecl" match="type[@isClass='true']">
    <xsl:text>public class </xsl:text>
    <xsl:value-of select="@caption"/>
  </xsl:template>
  <xsl:template mode="summaryDecl" match="type[@isInterface='true']">
    <xsl:text>public interface </xsl:text>
    <xsl:value-of select="@caption"/>
  </xsl:template>
  <xsl:template mode="summaryDecl" match="type">
    <xsl:value-of select="@caption"/>
  </xsl:template>

  <!--ENUM MEMBERS-->
  <xsl:template mode="members" match="type[@isEnum='true']" >
    <xsl:text>== Members ==
</xsl:text>
    <xsl:apply-templates mode="enumField" select="../member[@memberType='Field']"/>
  </xsl:template>

  <!--CLASS MEMBERS-->
  <xsl:template mode="members" match="type[@isClass='true']">
    <xsl:if test="../member[@memberType='Field']">
      <xsl:text>== Fields ==
</xsl:text>
      <xsl:apply-templates mode="field" select="../member[@memberType='Field']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Property']">
      <xsl:text>== Properties ==
</xsl:text>
      <xsl:apply-templates mode="property" select="../member[@memberType='Property']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Method']">
      <xsl:text>== Methods ==
</xsl:text>
      <xsl:apply-templates mode="method" select="../member[@memberType='Method']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Event']">
      <xsl:text>== Events ==
</xsl:text>
      <xsl:apply-templates mode="event" select="../member[@memberType='Event']"/>
    </xsl:if>
  </xsl:template>

  <!--INTERFACE MEMBERS-->
  <xsl:template mode="members" match="type[@isInterface='true']">
    <xsl:if test="../member[@memberType='Field']">
      <xsl:text>== Fields ==
</xsl:text>
      <xsl:apply-templates mode="field" select="../member[@memberType='Field']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Property']">
      <xsl:text>== Properties ==
</xsl:text>
      <xsl:apply-templates mode="property" select="../member[@memberType='Property']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Method']">
      <xsl:text>== Methods ==
</xsl:text>
      <xsl:apply-templates mode="method" select="../member[@memberType='Method']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Event']">
      <xsl:text>== Events ==
</xsl:text>
      <xsl:apply-templates mode="event" select="../member[@memberType='Event']"/>
    </xsl:if>
  </xsl:template>

  <!--DEFAULT MEMBERS-->
  <xsl:template mode="members" match="type">
    <xsl:if test="../member[@memberType='Field']">
      <xsl:text>== Fields ==
</xsl:text>
      <xsl:apply-templates mode="field" select="../member[@memberType='Field']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Property']">
      <xsl:text>== Properties ==
</xsl:text>
      <xsl:apply-templates mode="property" select="../member[@memberType='Property']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Method']">
      <xsl:text>== Methods ==
</xsl:text>
      <xsl:apply-templates mode="method" select="../member[@memberType='Method']"/>
    </xsl:if>
    <xsl:if test="../member[@memberType='Event']">
      <xsl:text>== Events ==
</xsl:text>
      <xsl:apply-templates mode="event" select="../member[@memberType='Event']"/>
    </xsl:if>
  </xsl:template>

  <!--ENUM FIELD DOCUMENTATION-->
  <xsl:template match="member" mode="enumField">
    <xsl:text>=== `</xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text> = </xsl:text>
    <xsl:value-of select="@literalValue"/>
    <xsl:text>` ===
</xsl:text>
    <xsl:if test="summary">
      <xsl:value-of select="normalize-space(summary)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:if test="remarks">
      <xsl:text> </xsl:text>
      <xsl:value-of select="normalize-space(remarks)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
  </xsl:template>

  <!--DEFAULT FIELD DOCUMENTATION-->
  <xsl:template match="member" mode="field">
    <xsl:text>=== `public</xsl:text>
    <xsl:if test="@isStatic = 'true' and @isLiteral = 'false'">
      <xsl:text> static</xsl:text>
    </xsl:if>
    <xsl:if test="@isLiteral = 'true'">
      <xsl:text> const</xsl:text>
    </xsl:if>
    <xsl:text> </xsl:text>
    <xsl:value-of select="type/@caption"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>` ===
</xsl:text>
    <xsl:if test="summary">
      <xsl:value-of select="normalize-space(summary)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:if test="remarks">
      <xsl:text> </xsl:text>
      <xsl:value-of select="normalize-space(remarks)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
  </xsl:template>

  <!--PROPERTY-->
  <xsl:template match="member" mode="property">
    <xsl:text>=== `public</xsl:text>
    <xsl:if test="@isStatic = 'true' and @isLiteral = 'false'">
      <xsl:text> static</xsl:text>
    </xsl:if>
    <xsl:if test="@isLiteral = 'true'">
      <xsl:text> const</xsl:text>
    </xsl:if>
    <xsl:text> </xsl:text>
    <xsl:value-of select="type/@caption"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>` ===
</xsl:text>
    <xsl:if test="summary">
      <xsl:value-of select="normalize-space(summary)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:if test="remarks">
      <xsl:text> </xsl:text>
      <xsl:value-of select="normalize-space(remarks)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
  </xsl:template>

  <!--METHOD-->
  <xsl:template match="member" mode="method">
    <xsl:text>=== `public</xsl:text>
    <xsl:if test="@isStatic = 'true' and @isLiteral = 'false'">
      <xsl:text> static</xsl:text>
    </xsl:if>
    <xsl:if test="@isLiteral = 'true'">
      <xsl:text> const</xsl:text>
    </xsl:if>
    <xsl:text> </xsl:text>
    <xsl:value-of select="type/@caption"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>` ===
</xsl:text>
    <xsl:if test="summary">
      <xsl:value-of select="normalize-space(summary)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:if test="remarks">
      <xsl:text> </xsl:text>
      <xsl:value-of select="normalize-space(remarks)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
  </xsl:template>

  <!--EVENT-->
  <xsl:template match="member" mode="event">
    <xsl:text>=== `public</xsl:text>
    <xsl:if test="@isStatic = 'true' and @isLiteral = 'false'">
      <xsl:text> static</xsl:text>
    </xsl:if>
    <xsl:if test="@isLiteral = 'true'">
      <xsl:text> const</xsl:text>
    </xsl:if>
    <xsl:value-of select="type/@caption"/>
    <xsl:text> </xsl:text>
    <xsl:value-of select="@header"/>
    <xsl:text>` ===
</xsl:text>
    <xsl:if test="summary">
      <xsl:value-of select="normalize-space(summary)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
    <xsl:if test="remarks">
      <xsl:text> </xsl:text>
      <xsl:value-of select="normalize-space(remarks)"/>
      <xsl:text>

</xsl:text>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
