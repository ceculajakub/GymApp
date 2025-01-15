# Podsumowanie zasad programowania obiektowego w projekcie GymApp

Projekt GymApp oparty by� tworzony w oparciu o paradygmat programowania obiektowego, co umo�liwia zarz�dzanie danymi w spos�b uporz�dkowany, sp�jny i �atwy do rozszerzania.
Poni�ej opisze charakterystyczne pod tym wzgl�dem cz�ci projektu.

## 1. Enkapsulacja (Encapsulation)

Wszystkie klasy modeli danych, takie jak `ExerciseFormModel`, `ExerciseDoneViewModel`, `TrainingFormModel`, czy `TrainingViewModel`, stosuj� zasad� enkapsulacji,
przechowuj�c dane i zapewniaj�c dost�p do nich za pomoc� w�a�ciwo�ci (getter�w i setter�w). Dzi�ki temu dane s� chronione przed nieautoryzowan� modyfikacj�, a klasa pe�ni rol� "czarnej skrzynki",
ukrywaj�c szczeg�y implementacyjne. 

## 2.  Abstrakcja (Abstraction)

Klasy s�u��ce jako modele formularzy i widok�w `ExerciseFormModel`, `ExerciseDoneFormModel`, `TrainingViewModel`, itp.) pozwalaj� na ukrycie szczeg��w implementacyjnych w aplikacji,
skupiaj�c si� na danych istotnych z punktu widzenia aplikacji u�ytkownika. Klasa jest odpowiedzialna za prezentowanie tylko najwa�niejszych informacji, a nie za implementacj� szczeg��w jej funkcjonalno�ci.
Dane bior�ce udzia� w komunikacji aplikacji frontendowej z tym API b�d� mog�y w ten spos�b zosta� ograniczone tylko do minimalnego zestawu potrzebnego do wykonania ��danej operacji.

## 3. Zasada pojedynczej odpowiedzialno�ci (Single Responsibility Principle - SRP)

Ka�da klasa w projekcie stara si� spe�nia� zasad� pojedynczej odpowiedzialno�ci. Na przyk�ad klasy `ExerciseFormModel` i `ExerciseDoneFormModel` przechowuj� dane zwi�zane z formularzem �wicze�,
a `TrainingViewModel` przechowuje dane dotycz�ce wykonania ca�ego treningu. Ka�da klasa ma jedn�, jasno okre�lon� odpowiedzialno��, co poprawia czytelno�� i u�atwia utrzymanie kodu.

## 4. Zasada otwarte/zamkni�te (Open/Closed Principle - OCP)

Klasy s� zaprojektowane w taki spos�b, �e s� zamkni�te na modyfikacje, ale otwarte na rozszerzenia. Na przyk�ad, je�li chcemy doda� nowe w�a�ciwo�ci do modelu treningu,
mo�emy to zrobi� bez modyfikacji istniej�cego kodu, tylko rozszerzaj�c odpowiednie klasy.