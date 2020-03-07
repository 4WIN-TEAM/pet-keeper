## Zadatak:

Korišćenjem radnih okvira ASP.NET Core, Entity Framework, Bootstrap, Ajax, JQuery biblioteke realizovati Web Aplikaciju za prestavljanje Pet-keeper.

- Web aplikacija treba da sadrži:

	1. Posetiocima sajta pružiti opšte informacije o pansionu
	2. Pružiti posetiocima uvid u smeštajne kapacitete pansiona
	3. Pružiti posetiocima mogućnost besplatne registracije na sajtu
	4. Omogućiti registrovanim korisnicima online rezervaciju smeštajnog prostora za njihove ljubimce
	5. Vlasniku pansiona olakšati upravljanje resursima pansiona

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

