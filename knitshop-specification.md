# KnitShop — Projektna Specifikacija

> Naziv projekta je privremen i može se promeniti.
> Dokument se ažurira tokom planiranja.

---

## 1. Opis projekta

**KnitShop** je full-stack e-commerce web aplikacija za prodaju ručno rađenih pletenih proizvoda.
Projekat je namenjen sestri kao realan alat za online prodaju, a istovremeno služi kao portfolio projekat koji pokriva moderne full-stack tehnologije.

---

## 2. Korisničke uloge

| Uloga | Opis |
|---|---|
| **Gost** | Može da pregleda proizvode bez registracije |
| **Kupac** | Registrovan korisnik, može da poručuje i prati porudžbine |
| **Admin** | Sestra — upravlja proizvodima, porudžbinama i sadržajem |

---

## 3. Kategorije proizvoda

- Torbice
- Igračke
- *(može se proširiti: kape, šalovi, itd.)*

---

## 4. Proizvodi

- Svaki proizvod ima **ograničen broj komada** na stanju
- Svaki proizvod ima **3 do 5 slika**
- Proizvod se ne može poručiti ako nije na stanju

---

## 5. Dostava

- Dostava isključivo na teritoriji **Srbije**
- Cena dostave: **350 RSD**
- Besplatna dostava iznad **3.500 RSD**

---

## 6. Plaćanje

- **Pouzećem** — plaćanje kuriru pri preuzimanju
- **Online** — Stripe integracija (kartica)

---

## 7. Porudžbine — statusi

```
Primljeno → U pripremi → Poslato → Isporučeno
```

---

## 8. Recenzije

- Kupci mogu ostaviti **ocenu (1–5 zvezdica)** i **tekstualni komentar** na proizvod
- Recenziju mogu ostaviti **samo kupci koji su kupili taj proizvod**

---

## 9. Stranice aplikacije

### Kupac / Gost

| Ruta | Opis |
|---|---|
| `/` | Početna — istaknuti proizvodi, banner |
| `/products` | Svi proizvodi — filteri, pretraga |
| `/products/:id` | Detalji proizvoda — slike, opis, cena, dodaj u korpu |
| `/cart` | Korpa |
| `/checkout` | Poručivanje — adresa i način plaćanja |
| `/order-confirmation` | Potvrda porudžbine |
| `/login` | Prijava |
| `/register` | Registracija |
| `/profile` | Moj nalog — lični podaci |
| `/orders` | Moje porudžbine |
| `/orders/:id` | Detalji jedne porudžbine |

### Admin

| Ruta | Opis |
|---|---|
| `/admin` | Dashboard — statistike, nove porudžbine |
| `/admin/products` | Lista svih proizvoda |
| `/admin/products/new` | Dodavanje novog proizvoda |
| `/admin/products/:id` | Izmena postojećeg proizvoda |
| `/admin/orders` | Sve porudžbine |
| `/admin/orders/:id` | Detalji porudžbine + izmena statusa |

---

## 10. Tehnološki stack

### Frontend
| Tehnologija | Namena |
|---|---|
| React 18 | UI framework |
| TypeScript | Tipizacija |
| Redux Toolkit | State management (korpa, auth) |
| TanStack Query | Data fetching i caching |
| React Hook Form + Zod | Forme i validacija |
| Tailwind CSS + shadcn/ui | Stilizovanje |
| React Router v6 | Navigacija |
| Vitest + React Testing Library | Unit testovi |

### Backend
| Tehnologija | Namena |
|---|---|
| ASP.NET Core (.NET 8) | Web API framework |
| C# | Programski jezik |
| Entity Framework Core | ORM — komunikacija sa bazom |
| PostgreSQL | Relaciona baza podataka |
| JWT + Refresh Token | Autentifikacija |
| Role-based Authorization | Kupac vs Admin |
| AutoMapper | DTO mapiranje |
| FluentValidation | Validacija podataka |
| Serilog | Logging |
| Swagger / OpenAPI | Dokumentacija API-ja |
| xUnit + Moq | Unit testovi |

### Infrastruktura
| Tehnologija | Namena |
|---|---|
| Docker + docker-compose | Containerizacija |
| GitHub Actions | CI/CD pipeline |
| Stripe | Online plaćanje |
| Cloudinary | Upload i čuvanje slika |
| SignalR | Real-time notifikacija adminu za novu porudžbinu |
| SendGrid / MailKit | Email potvrda porudžbine |

---

## 11. Arhitektura backend-a

```
backend/
├── Controllers/       ← API endpointi (HTTP)
├── Services/          ← Poslovna logika
├── Repositories/      ← Komunikacija sa bazom
├── Models/            ← Entiteti baze podataka
├── DTOs/              ← Objekti za prenos podataka
├── Validators/        ← FluentValidation pravila
├── Mappings/          ← AutoMapper profili
└── Program.cs         ← Konfiguracija aplikacije
```

---

## 12. Struktura repozitorijuma

```
knitshop/
├── frontend/          ← React + TypeScript
├── backend/           ← ASP.NET Core C#
├── docker-compose.yml
└── README.md
```

---

## 13. Razvojne faze

### Faza 1 — Osnova
- [ ] Postavljanje projekta (repo, struktura foldera)
- [ ] Baza podataka — dizajn i migracije
- [ ] Backend: CRUD za proizvode
- [ ] Frontend: prikaz proizvoda

### Faza 2 — Autentifikacija i porudžbine
- [ ] Registracija i login (JWT)
- [ ] Korpa za kupovinu
- [ ] Kreiranje porudžbine
- [ ] Plaćanje pouzećem

### Faza 3 — Admin panel
- [ ] Admin dashboard
- [ ] Upravljanje proizvodima
- [ ] Upravljanje porudžbinama i statusima

### Faza 4 — Napredne funkcionalnosti
- [ ] Stripe integracija (online plaćanje)
- [ ] Upload slika (Cloudinary)
- [ ] Email notifikacije (potvrda porudžbine)
- [ ] SignalR (notifikacija adminu)
- [ ] Recenzije proizvoda

### Faza 5 — Kvalitet i deployment
- [ ] Unit testovi (frontend + backend)
- [ ] Docker konfiguracija
- [ ] GitHub Actions CI/CD
- [ ] Dokumentacija (README, Swagger)

---

## 14. Dijagram baze podataka

### Users
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| FirstName | string | |
| LastName | string | |
| Email | string | unique |
| PasswordHash | string | |
| PhoneNumber | string | |
| Role | enum | Customer, Admin |
| CreatedAt | datetime | |
| UpdatedAt | datetime | |

### Categories
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| Name | string | "Torbice", "Igračke" |
| Description | string | |

### Products
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| CategoryId | int | FK → Categories |
| Name | string | |
| Description | string | |
| Price | decimal | |
| Stock | int | broj komada na stanju |
| IsAvailable | bool | admin može sakriti proizvod |
| CreatedAt | datetime | |
| UpdatedAt | datetime | |

### ProductImages
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| ProductId | int | FK → Products |
| ImageUrl | string | link ka Cloudinary |
| IsMain | bool | glavna/naslovna slika |

### Orders
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| UserId | int | FK → Users |
| Status | enum | Primljeno, U pripremi, Poslato, Isporučeno |
| PaymentMethod | enum | Pouzece, Online |
| PaymentStatus | enum | Ceka, Placeno, Otkazano |
| DeliveryPrice | decimal | |
| TotalPrice | decimal | cena proizvoda + dostava |
| Note | string | napomena kupca, može biti null |
| CreatedAt | datetime | |
| UpdatedAt | datetime | |

### DeliveryAddresses
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| OrderId | int | FK → Orders |
| FullName | string | |
| PhoneNumber | string | |
| Street | string | |
| City | string | |
| PostalCode | string | |
| Country | string | default "Srbija" |

### OrderItems
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| OrderId | int | FK → Orders |
| ProductId | int | FK → Products |
| Quantity | int | |
| UnitPrice | decimal | cena u trenutku kupovine |
| Subtotal | decimal | Quantity x UnitPrice |

### Reviews
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| ProductId | int | FK → Products |
| UserId | int | FK → Users |
| OrderId | int | FK → Orders (provera kupovine) |
| Rating | int | 1 do 5 |
| Comment | string | |
| CreatedAt | datetime | |

### Payments
| Kolona | Tip | Napomena |
|---|---|---|
| Id | int | PK |
| OrderId | int | FK → Orders |
| Amount | decimal | |
| Method | enum | Pouzece, Online |
| Status | enum | Ceka, Uspesno, Neuspesno |
| StripePaymentIntentId | string | samo za online plaćanje, može biti null |
| PaidAt | datetime | može biti null |

### Relacije
```
Users ──────────── Orders ──────── OrderItems ──── Products
                      │                               │
              DeliveryAddresses              ProductImages
                      │
                  Payments

Users + Products + Orders ──── Reviews
```

### Napomena o normalizaciji
Baza je u **3NF** sa dva namerna izuzetka koji su industrijski standard:
- `OrderItems.Subtotal` — izvedena vrednost (Quantity x UnitPrice), čuva se zbog brzine i istorije
- `Orders.TotalPrice` — izvedena vrednost, čuva se zbog audita i tačnosti istorijskih podataka

---

## 15. Stavke za dogovoriti (TBD)

- [ ] Konačan naziv projekta / brenda
- [ ] Dizajn i boje sajta (predlog: krem, bež, roze, braon)
- [ ] Baza podataka — detaljan dijagram entiteta

---

*Specifikacija se ažurira tokom razvoja projekta.*
