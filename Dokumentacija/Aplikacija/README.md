## Zadatak:

Korišćenjem radnih okvira ASP.NET Core, Entity Framework, Bootstrap, Ajax i JQuery biblioteke realizovati WEB Aplikaciju "Pet-keeper" za predstavljanje i ONLINE rezervisanje prostora za kućne ljubimce.

### Web aplikacija treba da sadrži:

#### FRONTEND

1. Osnovna stranica za prikaz
2. Stranica za rezervacije
3. Stranica za informacije o samom hotelu
4. Stranica sa kontakt informacijama
5. Stranica za registraciju korisnika
6. Stranica za prijavu korisnika na sistem
7. Stranica za administraciju aplikacije

#### BACKEND

1. Baza podataka  - MSSQL
2. Aplikativni moduli pisani na 'ASP.NET Core' platformi.

## Aplikacija treba da obezbedi rad sa sledećim entitetima:

Pet:
- Id - Identifikator
- Ime - obavezna tekstualna vrednost sa najviše 50 karaktera
- Rasa - obavezna tekstualna vrednost birana kroz padajući meni (Enum)
- Pol - obavezna tekstualna vrednost birana kroz padajući meni (Enum)
- Starost - obavezna celobrojna vrednost iz intervala (0, 100]
- Stelirisan - obavezno polje (DA/NE)
- Vakcinisanost - obavezno polje (DA/NE)
- DatumPrijema - obavezno polje

## Napomena:

- Pas Mora biti uredno vakcinisan. Pas koji nije vakcinisan protiv besnila, zaraznog psećeg kašlja (Bordatella), unutrašnjih parazita i da ima zaštitu protiv buva i krpelja se ne prima u pansion. 
- Pansion ima odredjen broj kreveta za noćenje pasa. 
 (Potreban dogovor oko broja)

## Korisnici

- Administrator ima mogućnosti dodavanja, brisanja, izmene podataka u bazi.
- Registrovani korisnik može rezervisati, odnosno dodati svog psa i na taj način rezervisati mesto u pansionu.
- Posetioc sajta ima uvid samo o broju slobodnog smestaja, nema uvid u spisak(listu) trenutnih pasa u pansionu.

## Problematika
Dolazimo do sledeceg problema:

- Sta ako je danas neko rezervisao mesto za tek dve nedelje?
`Trenutan broj pasa treba izvršiti po današnjem danu.
Možda bi bilo najpametnije, odnosno najjednostavnije odraditi da se može rezervisati samo za sutra.
I na taj način izbeći koplikovanje pisanje koda. Bukvalno jedno drugo vuče i kreće sa komplikovanjem.

> Provera bi mogla da se vrši na nacin da se izvuče iz baze broj pasa koji imaju rezervisan smestaj za datum xx.xx.xxxx

## Testiranje aplikacije

Testiranje alikacije vršiće se na dva načina:

1. Testiranjem aplikacije kroz Unit Test

   * Pisanjem Unit Test-a proveravaće se ispravnost koda sa backend strane.
  Unit Test treba da sadrži proveru rada nam bazom podataka. (Provera CRUD-a)

2. Ručno testiranje aplikacije

   * Tester/korisnik će ručno prolaziti svaku postojeću funkciju u cilju pronalaska mogućih nedostataka u kodu.

