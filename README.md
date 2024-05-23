# SubnetApp
## Použití

1. **Spuštění aplikace:**
   - Spusťte aplikaci.
   - Budete vyzváni k zadání síťové adresy včetně masky (například `192.168.64.0/24`).

2. **Zadání IP adresy k ověření:**
   - Po zadání a validaci síťové adresy můžete zadávat další IP adresy.
   - Pro ukončení zadávání IP adres zadejte prázdný vstup (stiskněte Enter).

3. **Výstup:**
   - Aplikace vypíše `true`, pokud IP adresa spadá do zadané podsítě, nebo `false`, pokud nikoliv.

## Struktura Kódu

### IPAddressHandler

Třída `IPAddressHandler` je odpovědná za všechny operace spojené s IP adresami a maskami.

- `ValidatedSequence`: Vlastnost, kde je uložena validovaná síťová adresa.
- `CheckInputNet()`: Metoda pro kontrolu a validaci vstupní síťové adresy.
- `ParsedSequence()`: Metoda pro rozdělení validované sekvence na IP část a část masky.
- `IpPart()`: Metoda pro získání IP části validované sekvence.
- `MaskPart()`: Metoda pro získání části masky validované sekvence.
- `Address(string ip)`: Metoda pro konverzi řetězce na objekt `IPAddress`.

**Hodnoty pro testing:**

input: 192.168.15.0/24

192.168.15.1 -> TRUE
192.168.15.50 -> TRUE
192.168.15.255 -> TRUE
-----------------------
192.168.14.255 -> FALSE
192.168.16.1 -> FALSE
10.0.0.1 -> FALSE

input: 10.0.0.1/32

10.0.0.1/32 -> TRUE
-------------------
10.0.0.0 -> False
10.0.0.2 -> False
10.0.1.1 -> False
192.168.1.1 -> False

input: 192.168.15.0/28

192.168.15.1 -> TRUE
192.168.15.5 -> TRUE
192.168.15.14 -> TRUE
192.168.15.15 -> TRUE
---------------------
192.168.15.16 -> False
192.168.14.255 -> False
