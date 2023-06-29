# Dev Diary - Serious Games Projekt

Von Ella Pohl und Ruben Härle

## Aufgabe 1

### Zeitraum: 

- 23.Mai – 30.Mai

### Aufgaben:

Wir beide haben Unity installiert und angefangen die Entwicklungsumgebung zu erkunden. Dabei haben wir festgestellt, dass es verschiedene Templates für verschiedene Arten von Spielen gibt, zum Beispiel 3D Welten, oder 2D Runner Welten. Wir haben uns für eine plane 2D Welt entschieden, da dies am besten zu unserer Aufgabe gepasst hat. Dabei haben wir uns für unsere Erkundung stark an den bereitgestellten Links aus der Aufgabenstellung orientiert.

Als nächstes haben wir uns dazu entschieden ganz einfach anzufangen. Das heißt, wir haben als Bohrer ein Dreieck genommen und als Begrenzungen für die rechte und linke Seite zwei statische Rechtecke. Damit die Begrenzungen nicht aus dem Bild verschwinden, haben wir sie mit unserer Hauptkamera verbunden. So bewegen sich die Rechtecke immer dahin wo auch die Kamera hinbewegt wird.

![image-20230629105114548](./README_images/image-20230629105114548.png)

Als nächstes haben wir die Kamera mit ihrer y-Achse an die Kamera gekoppelt, damit wir der Drill immer folgen können. Bis jetzt ist der x-Achsen Wert der Drill ein fester Wert, soll aber in späteren Aufgaben überschrieben werden können. Aktuell fällt die Drill einfach nach unten und die Kamera folgt ihr.

```c#
// Camera default following the drill only on y direction
camera.transform.position = new Vector3(0, transform.position.y - centerOffsetCamera, -10); 
```

Unsere letzte Aufgabe für diese Woche war die Implementierung eines Menüs. Hierfür haben wir eine neue Szene angelegt in der wir einen Canvas angelegt haben in den wir Text und Buttons hinzugefügt haben, einmal um das Spiel zu starten und einmal um es zu beenden. Außerdem haben wir noch zwei Platzhalter hinzugefügt, einmal für einen Highscore und einen Slider, um möglicherweise später die Lautstärke zu regeln.

### Probleme:

Zu Anfang sind unsere Bildbegrenzungen nicht auf Höhe des Bohrers bzw. der Kamera geblieben. Nach einiger Recherche konnten wir herausfinden, dass man in der Hierarchie Objekte untereinander anordnen kann, was dazu führte, dass die Begrenzungen auf Höhe der Kamera und Bohrers blieben. 

Ein anderes Hindernis war die Implementierung des Menüs. Zu Anfang versuchten wir alles in einer Szene zu implementieren. Dies erwies sich jedoch als sehr schwierig. Deshalb entschieden wir uns eine separat Szene zu verwenden, und dort eine Transition zu einer anderen Szene mit Hilfe eines Buttons zu implementieren.  

```c#
public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text textUI;

    public void Start(){
        textUI.text = "Highscore:"; // here we will add the value of the highscore
    }
    
    public void move_to_scene(string scene_name) 
    {
        SceneManager.LoadScene(scene_name);
    }   
}
```

## Aufgabe 2

## Aufgabe 3

## Aufgabe 4

## Aufgabe 5

