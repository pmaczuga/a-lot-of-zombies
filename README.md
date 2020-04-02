# A Lot of Zombies

Prosta gra tworzona na silniku Unity w ramach przedmiotu: technologie gier komputerowych.

## Inspiracja
**Boxhead 2**

## Opis gry
### Cel gry
Bohater musi zabijać ciągle pojawiających się przeciwników. 
Celem gry jest przeżyć jak najdłużej i zdobyć jak najwięcej punktów. 
Gra rozpoczyna się na określonej planszy, która nie zmienia się aż do końca rozgrywki. 
Z czasem pojawia się coraz więcej przeciwników, co powoduje zwiększenie trudności a w ostateczności nieunikniony koniec rozgrywki.

### Bohater 
- Może chodzić
- Nie może skakać
- Używa broni
  - Różne rodzaje
  - Ulepszenia i dodatkowe rodzaje broni za kombo
  - Amunicja
    - Można ją otrzymać z martwego przeciwnika
- Stawia przedmioty (miny, wybuchowe beczki itp)
- Życie
  - Posiada określoną liczbę punktów życia
  - Życie regeneruje się z czasem oraz może być uzupełniane po zebraniu odpowiedniego przedmiotu po zabiciu przeciwnika
  
### Punkty
W grze jest licznik punktów i zdobycie jak największej ich ilości stanowi główny cel gry. 
Punkty dostajemy za zabijanie przeciwników. Punkty ustalają pozycję gracza w rankingu.
  
### Kombo
W grze istnieje mnożnik punktów, potocznie nazywany “kombo”, zwiększa się wraz z liczbą zabitych przeciwników, 
a stopniowo maleje, po pewnym czasie bez zabójstw (np. 1s).

### Przeciwnicy
Przeciwnicy pojawiają się na planszy w z góry określonych miejscach. 
W każdej rundzie jest ich coraz więcej, pojawiają się też nowe ich typy.
Typy:
- Powolne zombie - atakują wręcz. 
- Diabły - strzelają kulami ognia w gracza. Mogą ranić swoich sojuszników, 
  a także niszczyć zbudowane przez gracza mury / wysadzać wybuchowe beczki.

### Przeszkody
Czyli wszystkie stacjonarne obiekty, które stanowią blokadę dla gracza i przeciwników. Blokują także pociski z broni.
Dwa rodzaje:
- Niezniszczalne 
  - Stanowią część mapy 
  - Nie mogą być stawiane przez gracza
- Zniszczalne 
  - Wszystkie obiekty, które można zniszczyć
  - Mogą to być:
    - Mury
    - Wybuchowe beczki
- Mogą mieć różną wytrzymałość. Przykładowo beczki wybuchają po jednym celnym strzale, natomiast mur wytrzyma ich znacznie więcej. 
- Niektóre z nich mogą być stawiane przez gracza

### Plansze
W grze jest możliwość wyboru jednej z kilku różnych gotowych map. 
Plansze te różnią się od siebie rozmieszczeniem niezniszczalnych elementów, 
miejscem z którego wychodzą przeciwnicy oraz wielkością. 
Przykładowo jeden poziom może mieć mnóstwo otwartej przestrzeni oraz przeciwników 
pojawiających się przy każdej krawędzi mapy, z kolei inny może zawierać w sobie swoisty 
labirynt niezniszczalnych bloków, a przeciwnicy mogą pojawiać się tylko na niewielkiej 
centralnej przestrzeni horyzontalnej krawędzi mapy. Dodatkowo niektóre mapy mogą mieścić 
się na jednym ekranie, a inne być większe, przez co nie ma możliwości śledzenia każdego 
ruchu wykonywanego na danej planszy. Każda plansza jest podzielona na kwadraty, w obrębie 
jednego z nich może znaleźć się tylko jedna przeszkoda. Siatka ta nie wpływa na możliwość 
ruchu graczy ani przeciwników.

### Grafika 3D
Na każdym poziomie kamera jest ustawiona w rzucie izometrycznym. W centralnym punkcie 
zawsze znajduje się bohater, więc jeżeli mapa nie mieści się na jednym ekranie, kamera 
będzie się poruszać z każdym ruchem gracza. Gdy gracz znajdzie się blisko krawędzi ekranu, 
kamera nie będzie próbować dalej za nim podążać, tylko zatrzyma się w taki sposób żeby 
zostawiała graczowi jak najwięcej informacji o otaczającym go świecie.

### Efekty dźwiękowe
Strzały, odgłosy zabijania przeciwników, odgłosy ranienia bohatera, wybuchy beczek, kombo (darmowe źródła)

### Fizyka
- Bohater zatrzymuje się na przeciwniku
- Pociski odbijają się od lub niszczą przeszkody i przeciwników

### Technologie
Unity - silnik graficzny, w którym powstanie gra    
Blender - program do tworzenia modeli 3d, oraz animacji

### Potencjalne ulepszenia gry
- Tryb multiplayer (offline)
- Efekt rozprysku krwi i plamy na podłodze
- Więcej rodzajów przeciwników
- Wiele rodzajów broni
- Bohater może zdobywać umiejętności (np. większa szybkość, większa częstotliwość strzałów)
- Plansze generowane proceduralnie
