<title>No title</title>
<link href="style.css" rel="stylesheet" type="text/css" />
<body>
<center>
<br>
<font size="1"></font><p>
<table><tr><td align="left" class="style1">
<div id="ul">
<?php

$dir = "uploadmap/";  // dezelfde map als bij het uploaden
$exten = array('widm', 'WIDM');  // de toegestaande extensies
if ($handle = opendir($dir))
{
    while (false !== ($file = readdir($handle))) {
        $bestand = $dir ."". $file ;
        $ext = pathinfo($bestand);
        if(in_array($ext['extension'], $exten))
        {
        for($i=1; $i<=$count-2; $i++)
            $suffix .= '' . $temp[$i];
                 print(ucfirst("-- <a href='$dir". $file ."' onmouseover=\"popup(')\"; onmouseout=\"stopthumb()\"> ".substr($file, 0, strlen($file) - (strlen($file) - strrpos($file, ".")))." </a> --<br>"));
        }
    }
    if (empty($handle))
    {
    
        echo "Nog geen bestanden geupload";
        
    }
    closedir($handle);
}

?>
</div>

</td></tr>
</table> 

