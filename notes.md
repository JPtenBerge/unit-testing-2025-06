# Notes

## Intro

Naamgeving van testmethoden
- consistent

- `Add_OnePositiveInteger_CalculatesCorrectly()`
- `Add_MixOfPositiveAndNegativeIntegers_CalculatesCorrectly()`
- `One_Positive_Integer_In_Calculator_Calculates_Result()`
  - feature-driven, lijkt op wat in JS/TS meer normaal is:
    ```ts
    it('should calculate a correct result with one positive integer', () => {

    });
    test('should calculate a correct result with one positive integer', () => {

    });
    ```

### Black box vs white box

black box
- wat erin, wat eruit

white box
- interne state

### `private`

zou je dit moeten testen?

- idealiter: via de public API
- rechtstreeks enkel als de public API te ingewikkeld/omslachtig/complex is
  - dat gebeurt dan via reflection, maar resulteert eigenlijk nooit in mooie leesbare code


## Testframeworks

- MSTest
- xUnit
  - heeft momenteel nog een heel klein beetje JP's voorkeur
- NUnit

Maar, verschillen?
- beetje syntax
- ooit best wat. tegenwoordig _nauwelijks_.
- xUnit-pagina met verschillen in tabel: https://xunit.net/docs/comparisons
  - Met name die `[TestInitialize]` is een interessante, waar xUnit daar de constructor gebruikt
    - met een groot aantal tests kun je dan geen expliciete `override` doen op je base-initialisatie
    - ook `await` in je initializer gebruiken kan dan niet, want een constructor kun je niet als `async` definieren
    - zie ook de niet-geaccepteerde maar wel waardevolle antwoorden hier: https://stackoverflow.com/questions/334515/do-you-use-testinitialize-or-the-test-class-constructor-to-prepare-each-test-an

## Testen identificeren

Right BICEP:

- Are the results Right?
- Boundaries
- Inversion
- Cross-check
- Error conditions
- Performance

## Test-driven development

Eerst test schrijven, daarna pas code

1. Test schrijven
2. Test runnen en zien dat hij faalt
3. Code schrijven - minimaal stukje code schrijven
4. Test(s) runnen en zien dat hij SLAAGT
5. Refactor

repeat.

## Mock frameworks

- Moq
- NSubstitute
- FakeItEasy
- RhinoMocks
  - oud, wordt niet meer onderhouden
- Microsoft Fakes
  - voor het mocken van static spul als `DateTime.Now` of `File.AppendAllText()`

## Mocken

"er muren in kunnen schuiven" - nepimplementaties in plaats van echte

- dependency injection is een veelgezien pattern om dit te faciliteren
  - bij het opstarten configureren dat je voor X een Y wil aanleveren
  - een vorm van inversion of control
  - interface

test doubles: vergelijkbaar met stunt double

- dummy: een verplchte parameter die niet relevant is voor de test
  ```cs
  service.Doe(x, y, bla, hoi);
  ```
- fake
- mock: intelligentie++
  - nepimplementatie
  - verschillende returnwaarden
- stub: registreert interactie
  - welke methode is aangeroepen
  - hoe vaak
  - met welke parameters

## Handmatig mocken

Met een handmatige mock hou ik handmatig bij dat een methode is aangeroepen. Maar ik wil meer:

- exact 1 keer
- exact 4 keer
- minimaal 4 keer
- met welke parameters
  - met welke parameters de derde aanroep
- verschillende tests => verschillende returnwaarden
  - exceptions throwen

## Mock frameworks

Moq:
```cs
// Arrange
var mock = new Mock<INavigateService>();
mock.Setup(x => x.Next()).Returns(14);
mock.Setup(x => x.Next()).ReturnsAsync(14);
mock.Setup(x => x.Next()).Throws<ArgumentException>();

// verderop

// Assert
mock.Verify(x => x.Next(), Times.Exactly(4));
```

## Code coverage

- in hoeverre je code gedekt wordt door unittests
- niet zo heel betrouwbaar

soorten coverage:
- method coverage
- line coverage
- statement coverage
- branch/block coverage

```cs
public void Doe()
{
	var x, y, p = 4; // meerdere statements op 1 regel

	if ( )
	{

	}
	for ()
	{

	}
}
```

```cs
// please don't ever do this. liever transparant zijn dat je project maar 50% CC heeft dan "doen alsof"
[TestMethod]
public void DoeTest()
{
	try {
		sut.Doe();
	}
	catch {}
}
```

## Mutation testing

```cs
// productiecode
if (x > 4) {
	// ...
}

if (x < 4) { // mutant
if (x == 4) { // mutant
if (x > 4000) { // mutant
if (x == "") { // mutant
```

## Verder

- Bowling kata voor TDD oefenen: https://codingdojo.org/kata/Bowling/

### Visual Studio vs Rider

- Rider is iets meer dan 80% goedkoper dan VS
- VS is pas sinds de laatste versie 64-bit
  - 32-bit 2^32 4GB
  - ReSharper  (JetBrains)
- VS is slecht in HTML/CSS/JS/TS
- VS heeft basale ondersteuning voor multiple startup projects
  - Rider heeft runconfiguraties
- Rider heeft betere/slimmere autocompletions
- VS met shift+delete blocking modal dialog "Waiting for a background operation to complete"
- VS gooit standaard bin/obj niet leeg bij Clean solution
- VS start losse terminal-schermpjes, Rider integreert ze met tabbladen
- Rider heeft "Search everywhere" om snel/makkelijk naar bestanden te gaan
  - shift+shift
