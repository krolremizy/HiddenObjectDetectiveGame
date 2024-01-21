INCLUDE globals.ink

Dzień dobry, czy mogę jakoś pomóc?

-> main

=== main ===
* [Zapytaj o ofiarę] Czy pani Eleanor miała ostatnio jakieś kłopoty?
    Eleanor była tak wspaniałą osobą. Nie, nie miała żadnych problemów.
    -> main
* [Zapytaj o gości] Czy zna pani pozostałych gości?
    Tak, Miguel Bennett to znajomy Eleanor. Znali się stosunkowo krótko, widziałam go może dwa razy w życiu. Z kolei z Anią widziałam się wielokrotnie. Eleanor była jej ciocią.
    -> option2
* [Zapytaj o podejrzenia] Czy zaobserwowała pani coś niepokojącego? Coś nietypowego?
    Nie, nie do końca... Chociaż... Ania zdawała się być trochę, hmm, nieobecna.
    -> option3
* {kitchen_clue} [Zapytaj o kapelusz] Czy coś pani mówi ten kapelusz?
Ach, to kapelusz Eleanor. Co on tutaj robi?
    -> option4
* {hall_clue} [Zapytaj o nóż] Co pani wiadomo na temat tego noża?
Niestety nie. Choć wydaje mi się, że widziałam, jak Miguel używał go do krojenia ciasta.
    ->option5
* {livingroom_clue} [Zapytaj o rękawiczkę] Co pani wiadomo na temat tej rękawiczki?
    Jestem prawie pewna, że należała do Eleanor. Dziwne, jak znalazła się w salonie.
    Dobrze, dziękuję.
    -> main
* ->
-> DONE

=== option2 ===
* [Podpytaj o Miguela] Co pani wie o panu Bennetcie?
    Tak jak mówiłam, niewiele. Poznali się na jakimś kole, ale nie jestem sobie w stanie przypomnieć. Nienawidzę plotkować.
    -> option2
* [Podpytaj o Anię] Co pani wie o Anii?
    Eleanor była jej ciocią. To jej jedyna rodzina, biedulka spędzała z Eleanor bardzo dużo czasu i jej pomagała w domu.
    -> option2
* ->
-> main

=== option3 ===
* [Nieobecna?] W jakim sensie nieobecna?
    Można powiedzieć, że wczorajszego wieczoru była we własnym świecie. Nie brała udziału w rozmowie, opuszczała salon.
    -> option3
* [A Miguel?] A co z panem Bennettem?
    Prawdę mówiąc, nie za bardzo za nim przepadam. Jakiś taki, nie wiem. Nie wiem co ona w nim widziała. Nie zdziwię się, jak to on ją zabił.
    -> option3
* ->
-> main

=== option4 ===
* Tak, mnie też to ciekawi.
    Wcześniej byliśmy wszyscy na spacerze. Gdy przyszliśmy do domu, Ania zebrała wszystkie nasze płaszcze i kapelusze, żeby odnieść na wieszaki.
    -> option4
* ->
-> main

=== option5 ===
* Jak bardzo jest pani tego pewna?
    Ręki bym sobie nie dała uciąć, ale ten mężczyzna cały jest jakiś podejrzany.
    -> option5
* ->
-> main

-> END
