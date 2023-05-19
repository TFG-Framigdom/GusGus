# GusGus
 El objetivo del proyecto es el diseño e implementación de un videojuego web ejecutable en escritorio, usando las tecnologías de Unity. La temática de la aplicación versará por un sistema de laberintos aleatorios con enemigos , en el cual el jugador deberá sobrepasar en el menor tiempo posible. 
 
 # Crea tu propio Laberinto
 
 Una de las facilidades que te ofrece este proyecto, es poder crear tu laberinto a tu gusto, pero para ello hay que seguir unas ciertas reglas. En GusGus se usa el formato JSON, para quien no lo conozca es un formato de texto sencillo para el intercambio de datos. Es importante saber su estructura y sintaxis para poder hacer el laberinto y que no te reconozcan errores. Para mas información acerca de su sintaxis, dejo este enlace https://www.mclibre.org/consultar/informatica/lecciones/formato-json.html.
 
Empezemos por como abrir un JSON y qeu te devuelva un JSON. Hay miles de formas de hacerlo, dejo 3 maneras comodas para el lector:
1. Utilizando Visual Studio, en "New File" y en el mismo nombre que termine con ".json" y el propio visual studio reconocerá el JSON, muy cómodo para trabajar desde ahi y te devolverá un JSON al guardar.
2. Utilizando una Herramienta online como esta: https://jsoneditoronline.org/#left=local.wuloci&right=local.likija. Entras y solo necesitas trabajar en un documento, en ese mismo escribes el JSON y luego solo tienes que guardarlo en tu escritorio.
3. Otra manera un poco mas ruda, es desde un Bloc de Notas, escribes el JSON y al guardar, terminas su nombre con la extension ".json".

Ahora que tenemos conocimiento de JSON, solo nos queda presentar la estructura que debe tener el JSON, empezemos con un ejemplo para verlo mejor:



![image](https://github.com/TFG-Framigdom/GusGus/assets/80247805/9c832e3e-44ac-494b-aaaa-de87f7e6458a)


Como podemos obervar las llaves que abren y cierran son muy importantes sino no te lo reconcocerá como un objeto JSON, y luego dentro de esas llaves solo tenemos 5 atributos:
1. Tamaño: Que es una lista([]) con dos numeros, lo que indica el tamaño del laberinto en X y en Y. Importante el tamaño que se ponga se debe corresponder luego en los laberintos, es decir si pones [8,8] el laberinto va a tener un tamaño de x=8 y de y=8, por lo tanto tendra 64 valores (8x8) dentro. Recomendable usar los mismos numeros de tamaño.
2. Tiempo: Es el tiempo que tarde la partida en **segundos**, es decir que si pones 80, en el juego saldrá 01:20.
3. Laberintos: Laberinto, LaberintoLevel2 y LaberintoLevel3, son los laberintos de los distintos niveles, impportante poner los tres ya que el juego esta hecho por 3 niveles siempre y tener en cuenta lo dicho anteriormente del tamaño en los 3. Vamos a centrarnos en el atributo "Laberinto" para explicar como se hace ya que los 2 atributos restantes serian igual pero cambiando los valores. Como se puede observar es una lista de numeros, en concreto una lista que contiene 64 numeros. Aconsejamos ver la lista de numeros como en el ejemplo para ver bien el laberinto. Empecemos por los valores que hay dentro del laberinto:
```

 1 - Paredes del Laberinto
 0 - Caminos del Laberinto (El jugador podrá pasar por estos caminos)

```




Muy importante que al crear el JSON, se haga con los mismos nombres que los atributos y con una estructura básicamente muy similar al ejemplo con tan solo tengas que cambiar los valores, ya que sino sera muy tedioso por que devolverá errores la aplicación.Dejo el ejemplo de antes, accesible para mayor comodidad al copiar y reestructurar valores:

{

    "Tamano": [8,8],
    "Tiempo": 10,
    "Laberinto": [ 1,1,1,1,1,1,1,1,
    1,0,0,0,0,2,0,3,
    1,0,1,1,0,2,0,1,
    1,4,21,22,0,0,1,1,
    1,1,0,0,0,0,0,1,
    1,23,0,23,0,0,0,1,
    1,0,52,52,1,52,2,1,
    1,1,1,1,1,1,1,1],
    "LaberintoLevel2": [ 1,1,1,1,1,3,1,1,
                         1,0,0,52,0,2,0,1,
                         1,0,1,1,1,1,0,1,
                         1,0,0,2,0,0,1,1,
                         1,0,0,0,0,1,1,1,
                         1,0,0,2,0,22,0,1,
                         1,4,0,23,1,21,2,1,
                         1,1,1,1,1,1,1,1],
                    "LaberintoLevel3": [ 1,1,1,1,1,3,1,1,
                                             1,0,0,52,23,23,23,1,
                                             1,0,0,0,1,1,0,1,
                                             1,0,0,2,0,0,1,1,
                                             1,0,0,0,0,1,1,1,
                                             1,0,0,2,0,22,0,1,
                                             1,4,0,0,1,21,2,1,
                                             1,1,1,1,1,1,1,1]
                                             

}
