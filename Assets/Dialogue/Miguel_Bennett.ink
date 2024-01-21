INCLUDE globals.ink

W czym mogę pomóc?

-> main

=== main ===
* [Zapytaj o ofiarę] Chciałem zapytać o ofiarę. Co pan wie o pani Eleanor?
    Eleanor była mi bardzo bliską osobą. Poznaliśmy się na kole czytelniczym.
    -> option1
* [Zapytaj o mężczyznę] Co pan robił w tym domu?
    Pani Eleanor zaprosiła mnie na kolację. Wczoraj miała urodziny, więc celebrowaliśmy je w kika osób.
    -> option2
* {hall_clue} [Zapytaj o nóż] Czy mówi coś panu ten nóż?
    To... Och, pani Thornton kroiła nim wczoraj tort. Nie wiem, czemu znalazł się w holu.
    -> main
* {kitchen_clue} [Zapytaj o kapelusz] Czy mówi coś panu ten kapelusz?
    Tak, to kapelusz Eleanor. Dałem jej go jako prezent na urodziny rok temu. Szkoda, że jest ubrudzony krwią...
    -> option3
* {livingroom_clue} [Zapytaj o rękawiczkę] Co pan wie o tej rękawiczce?
    Jestem prawie pewny, że widziałem ją na dłoni Eleanor.
    Dziękuję za pomoc.
    Nie ma za co.
    -> main
* ->
-> DONE
    
=== option1 ===
* [Bliską przyjaciółką?] Państwo byli przyjaciółmi?
    Tak, bardzo dobrymi.
    -> option1
* [Bliską kochanką?] Czy państwo byli... kimś więcej niż znajomymi?
    Nie, mnie i panią Whittaker łączyła jedynie przyjaźń.
    -> option1
* ->
-> main

=== option2 ===
* [Zapytaj o gości] Zna pan pozostałych gości?
    Nie za dobrze. Kojarzę jedynie panią Thornton, starszą sąsiadkę Eleanor. Przyjaźniły się wiele lat, to były dobre przyjaciółki. Mówiły sobie o wszystkim.
    -> option2
* [Zapytaj o podejrzenia] Czy zaobserował pan może coś niepokojącego? Może pan coś widział?
    Ta młoda dama... Wydawała się bardzo niespokojna i w trakcie kolacji wychodziła kilkukrotnie do salonu.
    -> option2
* ->
-> main

=== option3 ===
* [Zeszłoroczne urodziny?] Jak dawno poznał pan panią Whittaker?
    Trochę ponad półtora roku temu.
-> main

-> END
