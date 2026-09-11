# CatFoodCalculator

WPF-rakendus, mis arvutab kassi päevase toidukoguse ja vajaliku toidukoguse valitud perioodiks.

## Käivitamine

1. Ava projekt Visual Studio 2026-s.
2. Käivita projekt `CatFoodCalculator.WpfApp`.
3. Sisesta vajalikud väärtused ja vajuta `Arvuta`.

## Sisendid

- Kassi kaal (kg): 0,1–30 kg
- Kalorinorm: 1–500 kcal/kg
- Toidu kalorsus: 1–1000 kcal/100 g
- Päevade arv: 1–365

## Arvutuse eeldused

Kasutaja sisestab ise kassi päevase kalorinormi ühe kilogrammi kehakaalu kohta.

Päevane kalorivajadus:

`kassi kaal × kcal/kg`

Päevane toidukogus:

`päevane kalorivajadus / kcal 100 g kohta × 100`

Kogu toidukogus:

`päevane toidukogus × päevade arv / 1000`

Päevane toidukogus ümardatakse ühe komakohani.

Kogu toidukogus kilogrammides ümardatakse kahe komakohani.

Kalkulaator on õppeotstarbeline ega määra ise kassile sobivat kalorinormi.

## Kontrollnäide 1 – korrektne sisend

Sisend:

- Kassi kaal: 4 kg
- Kalorinorm: 50 kcal/kg
- Toidu kalorsus: 400 kcal/100 g
- Päevade arv: 30

Oodatud tulemus:

- Päevane toidukogus: 50,0 g
- 30 päevaks vajalik kogus: 1,50 kg

## Kontrollnäide 2 – vigane sisend

Sisend:

- Kassi kaal: 50 kg
- Kalorinorm: 50 kcal/kg
- Toidu kalorsus: 400 kcal/100 g
- Päevade arv: 30

Oodatud veateade:

`Kassi kaal peab olema vahemikus 0,1–30 kg.`