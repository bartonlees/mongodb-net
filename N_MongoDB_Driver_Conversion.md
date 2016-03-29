# Summary #
Endianess conversion support
# Remarks #
<pre>
"Miscellaneous Utility Library" Software License<br>
<br>
Version 1.0<br>
<br>
Copyright (c) 2004-2008 Jon Skeet and Marc Gravell.<br>
All rights reserved.<br>
<br>
This product includes software developed by Jon Skeet<br>
and Marc Gravell. Contact skeet@pobox.com, or see<br>
http://www.pobox.com/~skeet/<br>
<br>
THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESSED OR IMPLIED<br>
WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF<br>
MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.<br>
IN NO EVENT SHALL JON SKEET BE LIABLE FOR ANY DIRECT, INDIRECT,<br>
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,<br>
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;<br>
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER<br>
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT<br>
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN<br>
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE<br>
POSSIBILITY OF SUCH DAMAGE.<br>
</pre>


# Enumerations #
| **Enumeration** | **Summary** |
|:----------------|:------------|
| [Endianness](T_MongoDB_Driver_Conversion_Endianness.md) | Endianness of a converter |


# Classes #
| **Class** | **Summary** |
|:----------|:------------|
| [BigEndianBitConverter](T_MongoDB_Driver_Conversion_BigEndianBitConverter.md) | Implementation of [EndianBitConverter](T_MongoDB_Driver_Conversion_EndianBitConverter.md) which converts to/from big-endian byte arrays. |
| [EndianBitConverter](T_MongoDB_Driver_Conversion_EndianBitConverter.md) | Equivalent of [BitConverter](http://msdn.microsoft.com/en-us/library/System.BitConverter.aspx) , but with either endianness. |
| [LittleEndianBitConverter](T_MongoDB_Driver_Conversion_LittleEndianBitConverter.md) | Implementation of [EndianBitConverter](T_MongoDB_Driver_Conversion_EndianBitConverter.md) which converts to/from little-endian byte arrays. |
