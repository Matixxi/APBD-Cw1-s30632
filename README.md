# Wypożyczalnia Sprzętu - APBD Ćwiczenia 2

Aplikacja konsolowa w C# obsługująca uczelnianą wypożyczalnię sprzętu.

## Uruchomienie
```
dotnet run --project zadanies30632
```

## Struktura projektu

Projekt podzieliłem na trzy warstwy:
- **Models** - klasy danych (Equipment, User, Rental)
- **Services** - logika biznesowa (RentalService, ReportService, PenaltyCalculator)
- **UI** - wyświetlanie i scenariusz demonstracyjny (ConsoleUI)

## Decyzje projektowe

**Podział odpowiedzialności** - każda klasa robi jedną rzecz. `PenaltyCalculator` tylko liczy kary, `RaportService` tylko wyświetla raporty, `RentalService` tylko zarządza wypożyczeniami. Gdybym wrzucił to wszystko do jednej klasy, zmiana jednej rzeczy mogłaby popsuć drugą.

**Dziedziczenie** - `Equipment` i `User` są abstrakcyjne bo nie ma sensu tworzyć "ogólnego sprzętu" czy "ogólnego użytkownika". Limit wypożyczeń (`MaxRentals`) jest zdefiniowany w każdej klasie osobno - Student ma 2, Pracownik ma 5.

**Reguły biznesowe w jednym miejscu** - stawka kary jest w `PenaltyCalculator` jako stała `PenaltyPerDay`. Żeby zmienić stawkę wystarczy zmienić jedną linię.

**Niskie coupling** - `RaportService` dostaje listy danych przez konstruktor zamiast odwoływać się bezpośrednio do `RentalService`. Dzięki temu obie klasy są od siebie niezależne.

## Scenariusz demonstracyjny

Program pokazuje: dodanie sprzętu i użytkowników, poprawne wypożyczenie, próbę przekroczenia limitu, próbę wypożyczenia niedostępnego sprzętu, zwrot w terminie, zwrot z opóźnieniem i karą, oraz raport końcowy.
