<link href="style.css" rel="stylesheet" type="text/css" />
<center><p><h1>Uploaden</h1></p>
<?php
$map = "uploadmap/";  //map waar naar geupload moet worden

$max = "10000000000";  //max bytes

$ext = "widm WIDM";  //toegestaande extensies


if ($_POST['Uploaden'])
{  
    if (!$_FILES['bestand'])  
        print ("Geef een bestand op!"); 
    else
    {  

        $bestand2 = explode("\\", $_FILES['bestand']['name']);  
        $laatste = count($bestand2) - 1;  
        $bestand2 = "$bestand2[$laatste]";   
        $bestand2 = str_replace(" ", "", "$bestand2"); 
        $bestand2 = strtolower($bestand2);

        
        $bestand3 = explode(".", $bestand2);  
        $laatste = count($bestand3) - 1;  
        $bestand3 = "$bestand3[$laatste]";   
        $bestand3 = strtolower($bestand3);  
            
        $ext = strtolower($ext);  
        $ext = explode(" ", $ext);  
        $aantal = count($ext);  
        
        for ($tel = 0;$tel < $aantal; $tel++)
        {  
            if ($bestand3 == $ext[$tel])
            {  
                $extfout = "nee";  
            }
        }  
    
        if (!$extfout)
        {  
            print ("Het bestand <b>$bestand2</b> kan niet worden geupload omdat de extensie niet is toegestaan!");  
        }  
        else  
        {  
            if ($_FILES['bestand']['size'] > $max)  
                print ("Het bestand <b>$bestand2</b> is groter dan $max bytes!");  
            else  
            {   
                $file = $map ."". $bestand2;
                move_uploaded_file($_FILES['bestand']['tmp_name'], "$file");  
                print ("Het bestand <b>\"$bestand2\"</b> is met succes geupload!<br>"); 
            }  
        }
    }
}  

print ("<form method=post action=" . $_SERVER['PHP_SELF'] . " enctype=multipart/form-data> 
Bestand: <input type=\"file\" name=\"bestand\"><br>
<input type=\"submit\" name=\"Uploaden\" value=\"Uploaden\"></form>");

 ?>