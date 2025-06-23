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
