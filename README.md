# Podsumowanie zasad programowania obiektowego w projekcie GymApp

Projekt GymApp oparty by³ tworzony w oparciu o paradygmat programowania obiektowego, co umo¿liwia zarz¹dzanie danymi w sposób uporz¹dkowany, spójny i ³atwy do rozszerzania.
Poni¿ej opisze charakterystyczne pod tym wzglêdem czêœci projektu.

## 1. Enkapsulacja (Encapsulation)

Wszystkie klasy modeli danych, takie jak `ExerciseFormModel`, `ExerciseDoneViewModel`, `TrainingFormModel`, czy `TrainingViewModel`, stosuj¹ zasadê enkapsulacji,
przechowuj¹c dane i zapewniaj¹c dostêp do nich za pomoc¹ w³aœciwoœci (getterów i setterów). Dziêki temu dane s¹ chronione przed nieautoryzowan¹ modyfikacj¹, a klasa pe³ni rolê "czarnej skrzynki",
ukrywaj¹c szczegó³y implementacyjne. 

## 2.  Abstrakcja (Abstraction)

Klasy s³u¿¹ce jako modele formularzy i widoków `ExerciseFormModel`, `ExerciseDoneFormModel`, `TrainingViewModel`, itp.) pozwalaj¹ na ukrycie szczegó³ów implementacyjnych w aplikacji,
skupiaj¹c siê na danych istotnych z punktu widzenia aplikacji u¿ytkownika. Klasa jest odpowiedzialna za prezentowanie tylko najwa¿niejszych informacji, a nie za implementacjê szczegó³ów jej funkcjonalnoœci.
Dane bior¹ce udzia³ w komunikacji aplikacji frontendowej z tym API bêd¹ mog³y w ten sposób zostaæ ograniczone tylko do minimalnego zestawu potrzebnego do wykonania ¿¹danej operacji.

## 3. Zasada pojedynczej odpowiedzialnoœci (Single Responsibility Principle - SRP)

Ka¿da klasa w projekcie stara siê spe³niaæ zasadê pojedynczej odpowiedzialnoœci. Na przyk³ad klasy `ExerciseFormModel` i `ExerciseDoneFormModel` przechowuj¹ dane zwi¹zane z formularzem æwiczeñ,
a `TrainingViewModel` przechowuje dane dotycz¹ce wykonania ca³ego treningu. Ka¿da klasa ma jedn¹, jasno okreœlon¹ odpowiedzialnoœæ, co poprawia czytelnoœæ i u³atwia utrzymanie kodu.

## 4. Zasada otwarte/zamkniête (Open/Closed Principle - OCP)

Klasy s¹ zaprojektowane w taki sposób, ¿e s¹ zamkniête na modyfikacje, ale otwarte na rozszerzenia. Na przyk³ad, jeœli chcemy dodaæ nowe w³aœciwoœci do modelu treningu,
mo¿emy to zrobiæ bez modyfikacji istniej¹cego kodu, tylko rozszerzaj¹c odpowiednie klasy.