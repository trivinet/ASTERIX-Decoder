# asterix-decoder

- VERSIÓN EN ESPAÑOL -

En este proyecto se ha desarrollado una aplicación de escritorio en el que pueden ser decodificados archivos en formato ASTERIX, 
un formato propio de Eurocontrol para la vigilancia y control de aeronaves.

Una vez se abre el archivo en el formato indicado (en este caso, sólo válido para la categoría 42) pueden analizarse los bits, 
bytes y blocks que componen el archivo, útil en el caso de archivos muy grandes como el de 'fichero_princial.ast', donde se tiene
la opción de elegir el número de blocks que se quieren analizar, y reducir tiempos de computación.

Para el caso de 'fichero_principal.ast', se adjuntan imágenes de los resultados obtenidos las diferentes pestañas disponibles de 
la aplicación.

Además, en este enlace puede verse un vídeo demostración del proyecto:
https://youtu.be/ivXk4ofJj1w

Las funciones principales del proyecto son 'Decoder.cs', 'DataItem.cs', 'DataBlock.cs' y 'ObjectDumper.cs', las cuales se encargan
de leer el archivo, agruparlo y descrifrar la codificación binaria en función de la normativa de Eurocontrol, encontrable en su web
oficial.



------------------------------------------------------------------



- ENGLISH VERSION -

This project consists in a desktop app that can be used to decode files in ASTERIX format, an exclusive Eurocontrol format used
for surveillance and control of aircrafts.

Once the file is opened (this must be done for exclusively cathegory 62 ASTERIX files), information such as bits, bytes or datablocks
that structure the file can be visualized, in order to choose the amount of them that is desired to decode, easing the computation
time.

In the case of 'fichero_principal.ast', some images are attached in this repository, so that the results obtained can be seen, as well
as the different tabs available in the app.

Moreover, in this link can be seen a brief demonstration of the project:
https://youtu.be/ivXk4ofJj1w

The main functions of this project are 'Decoder.cs', 'DataItem.cs', 'DataBlocks.cs' and 'ObjectDumper.cs', whose objective is to read,
organize and decipher the binary codification following the rules of Eurocontrol, that can be found in its official webpage.
