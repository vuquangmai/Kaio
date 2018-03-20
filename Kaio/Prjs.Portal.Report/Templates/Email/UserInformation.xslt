<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:param name="fullname"/>
	<xsl:param name="content"/>
	<xsl:template match="/">
		<html>

			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<title>User's Information</title>
				<style>
					body, form {
					margin: 0;
					}
					body {
					font-family: verdana, arial, helvetica, sans-serif;
					background: white;
					color: #366092;
					}
				</style>
			</head>
			<body>
				<table border="0" width="100%" style="font-size: 10pt; font-family: 'Arial">
					<tr>

						<td class="ms-formbody">
							<xsl:value-of select="$fullname"/>
							<br/>
							<xsl:value-of select="$content"/>
							<br/>
							Trân trọng,
							<br />
							Kaio Report
							<br/>
							http://vmgmedia.vn
						</td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>