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

## Verder

- Bowling kata: https://codingdojo.org/kata/Bowling/
