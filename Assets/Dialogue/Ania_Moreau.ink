INCLUDE globals.ink

To naprawdę przerażające... Dlaczego pani Eleanor...

-> main

=== main ===
* [Zapytaj o Eleanor] Czy były panie ze sobą blisko?
    Tak, pani Whittaker była dla mnie jak babcia. Nie mam bliskiej rodziny, a na niej zawsze mogłam polegać.
    -> option1
* [Zapytaj o gości] Co pani wie o pozostałych gościach?
    Pana Bennetta poznała na kole czytelniczym, mniej więcej półtora roku temu. Oboje wdowcy, nie wiem jakim cudem byli jedynie przyjaciółmi. Z kolei pani Thornton to sąsiadka cioci. Często przychodziła do nas na herbatę i plotki, uwielbiała to. Mówię do nas, bo przez ostatnie pół roku mieszkałam z ciocią.
    -> option2
* {livingroom_clue} [Zapytaj o rękawiczkę] Czy coś pani mówi ta rękawiczka?
    To... Tak. To rękawiczka cioci. Zakrwawiona... Boże, to naprawdę okropne.
    -> option3
* {kitchen_clue} [Zapytaj o kapelusz] Czy coś pani mówi ten kapelusz?
    Tak, to kapelusz cioci.
    -> option4
* {hall_clue} [Zapytaj o nóż] Czy coś pani mówi ten nóż?
    Nie... Zaraz, jeśli mnie pamięć nie myli, to pani Thornton kroiła nim tort urodzinowy.
    -> option5
* ->
-> DONE
    
=== option1 ===
* [Zapytaj o rodzinę] Co się stało z pani rodziną?
    Kilka lat temu rodzice zginęli w wypadku. Postanowiłam zwrócić się do jedynej osoby, jaka przychodziła mi do głowy. I tym sposobem znalazłam się tutaj.
    -> option1
* [Zapytaj o problemy] Czy pani Eleanor miała jakieś problemy?
    Nie, chyba nie. To poczciwa kobieta. Chociaż odkąd poznała pana Bennetta, zachowywała się trochę inaczej. Przy mnie zawsze opowiadała o nim z podekscytowaniem, a gdy pojawiałą się pani Thornton, to tak, jakby w ogóle nie znała tego faceta. Jakby nie istniał.
    -> option1
* ->
-> main

=== option2 ===
* [Opinia o Miguelu] Co pani myśli o panu Bennetcie?
    To prawdziwy dżentelmen. Bardzo pomocny i miły człowiek. Nie dziwię się, że ciocia go tak lubiła.
    -> option2
* [Opinia o Henriettcie] Co pani myśli o pani Thornton?
    Bardzo się z ciocią lubiły. Słodka, niewinna, starsza pani. Zawsze chwaliła moje ciasteczka.
    -> option2
* ->
-> main

=== option3 ===
* [Podejrzenia] Ma pani jakieś podejrzenia?
    Niestety, nie zwróciłam na nic uwagi. Wczoraj źle się czułam, kręciło mi się w głowie.
    ++[Zawroty głowy] Jakiś konkretny powód złego samopoczucia?
    Nie mam zielonego pojęcia. Wypiłam wieczorną herbatę i się zaczęło.
    -> option3
* ->
-> main

=== option4 ===
Znaleziono go w kuchni.
    W kuchni, ach. Nie mam pojęcia, co mógł tam robić. Możliwe, że upuściłam go, gdy odnosiłam ubrania gości po spacerze.
* ->
-> main

=== option5 ===
* [Czy pani to widziała?] Czy pani widziała, jak pani Thornton go używa?
    Tak, kroiła nim ciasto przy nas wszystkich. Potem niestety nie widziałam, kto ani gdzie go używa. Zakrwawiony...
    Tak, zakrwawiony.

-> END
