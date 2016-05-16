![alt tag](https://raw.githubusercontent.com/ooad-2015-2016/MALA/master/MALA%20LOGO.png)

# MALA 

Članovi tima: 
1. Milan Žuža
2. Adam Stanić
3. Lejla Zečević
4. Ajša Terko

# **Opis teme**

Mala app je aplikacija koja korisnicima usluga naših zabavnih parkova pruža jednostavan pristup informacijama koje će boravak u parku učiniti ugodnijim i zanimljivijim. Cilj aplikacije je da posjetiocu pomogne da pametno i efkasno iskoristi vrijeme provedeno u parku.
Rad aplikacije ce biti prezentiran na modelu izmišljenog zabavnog parka koji će se nalaziti na prostoru Kampusa Univerziteta u Sarajevu.


## **Procesi**

Administrator može da unosi evidenciju o radnicima, atrakcijama koje postoje u zabavnom parku i dodavanje novih usluga i modificiranje njhovih cijena. Nakon logovanja na sistem, odabere jednu od opcija za unos i shodno podacima o radniku, atrakciji i sl. unosi podatke, koji se nakon toga spašavanju u bazu podataka.

Korisnik tj. posjetioc će na ulazu u zabavni park biti obavezan da kupi kartu online ili na šalteru. Registrovani korisnici imaju mogućnost da unosom informacija o svojoj kreiditnoj kartici izvrše kupovinu ulaznice koju naknadno preuzimaju pri dolasku u park. Radnik na šalteru imaju mogućnost kreirati kartu sa unique kodom sa kojim se može pristupiti aplikaciji, datumom, cijenom, itd. Posjetioci koji kupovinu karte nisu obavili koristeći aplikaciju, istu mogu kupiti od radnika na šalteru na ulazu u zabavni park. 

Korisnik vrši login tako što kamera očita kod sa karte. Time mu je omogućen pristup svim korisnim informacijama koje boravak u parku treba da učine zanimljivijim i ugodnijim. Da bi on mogao da pristupi nekoj od atrakcija zabavnog parka, dužan je da prisloni svoju kartu na uređaj koji zatim očitava taj kod sa karte i omogućava mu prolazak do atrakcije. Ovakav sistem omogućava drugim posjetiocima zabavnog parka da u svakom trenutku, koristeći mobilnu aplikaciju, imaju informaciju o broju posjetioca koji čekaju u redu, te aproksimiranom vremenu čekanja za traženu atrakciju. 

Ako dođe do kvara ili zatvaranja atrakcije za posjetioce, radnik, koji koristi mobilnu aplikaciju, u mogućnosti je da promijeni status za datu atrakciju iz "Dostupna" u "Nije dostupna" odnosno iz "Zatvoreno" u "Otvoreno".

## **Funkcionalnosti**

- Vođenja evidencije o zaposlenicima zabavnog parka i atrakcijama istog
- Pristup izvještajima o broju postjeta parku i pojedinačnim atrakcijama
- Objavljivanje cijena atrakcija i popusta na iste
- Postavljanje statusa atrakcije
- Pregleda reda čekanja za neku atrakciju i aproksimiranom vremenu čekanja
- Pregleda mape zabavnog parka
- Ocjenjivanje usluga zabavnog parka; Feedback form
- Vremenska prognoza 

## **Akteri**

1. Administratori (ima pristup bazi zaposlenih, ima pristup izvještajima o radu zabavnog parka, u mogućnosti je da modifikuje cijenu karata i kreira posebne ponude)
2. Radnici koji održavaju atrakcije zabavnog parka (ima mogućnost da mijenja status atrakcija u parku, tj. da atrakciju učini dotupnom ili zatvorenom za posjetioce)
3. Radnici na ulaznom šalteru zabavnog parka (imaju pristup dijelu desktp aplikacije za prodaju karata)
4. Registrovani korisnici (imaju mogućnost kupovine karata online, te sakupljanju dodatnih bodova za specijalne pogodnosti)
5. Posjetioci zabavnog parka sa običnom kartom (koriste sve ranije navedene funkcionalnosti mobilne aplikacije)
6. Posjetioci zabavnog parka sa 'Gold' kartom (pored standardnih funkcionalnosti mobilne aplikacije, ovi posjetioci imaju mogućnost da koriste specijalni ulaz za pristup atrakciji sa smanjenim vremenom čekanja)


 



