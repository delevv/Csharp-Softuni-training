using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{

    [Test]
    public void CreateShouldThrowArgumentNullExceptionWhenValueIsNull()
    {
        var repo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => repo.Create(null));
    }

    [Test]
    public void CreateShouldThrowInvalidOperationExceptionWhenHeroAlreadyExists()
    {
        var repo = new HeroRepository();

        var hero = new Hero("Gosho", 999);

        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repo.Create(hero));
    }

    [Test]
    public void CreateShouldAddHeroCorrectly()
    {
        var repo = new HeroRepository();

        var hero = new Hero("Gosho", 999);

        repo.Create(hero);

        Assert.AreEqual(1, repo.Heroes.Count);
    }

    [Test]
    public void CreateShouldReturnCorrectMessageWheHeroIsCorrectlyAdded()
    {
        var repo = new HeroRepository();

        var hero = new Hero("Gosho", 999);

        var result = repo.Create(hero);

        var expectedMessage = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(expectedMessage, result);
    }

    [Test]
    public void RemoveShouldThrowArgumentNullExceptionWhenNameIsNullOrWhiteSpace()
    {
        var repo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => repo.Remove(null));
        Assert.Throws<ArgumentNullException>(() => repo.Remove(" "));
    }

    [Test]
    public void RemoveShouldDecreeseHeroesCountWhenHeroIsSuccsesfullyRemoved()
    {
        var repo = new HeroRepository();

        var hero = new Hero("Gosho", 999);

        repo.Create(hero);
        repo.Remove("Gosho");

        Assert.AreEqual(0, repo.Heroes.Count);
    }

    [Test]
    public void RemoveShouldReturnTrueWhenHeroIsSuccsesfullyRemoved()
    {
        var repo = new HeroRepository();

        var hero = new Hero("Gosho", 999);

        repo.Create(hero);

        var result = repo.Remove("Gosho");

        Assert.AreEqual(true, result);
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnCorrectResult()
    {
        var repo = new HeroRepository();

        var hero = new Hero("Ivan", 999);
        var hero2 = new Hero("Asen", 1);
        var hero3 = new Hero("Gosho", 100);

        repo.Create(hero);
        repo.Create(hero2);
        repo.Create(hero3);

        var resultHero = repo.GetHeroWithHighestLevel();

        Assert.AreEqual(999, resultHero.Level);
        Assert.AreEqual("Ivan", resultHero.Name);
    }

    [Test]
    public void GetHeroShouldReturnCorrectHero()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivan", 999);
        repo.Create(hero);

        var resultHero = repo.GetHero("Ivan");

        Assert.AreEqual("Ivan", resultHero.Name);
        Assert.AreEqual(999, resultHero.Level);
    }

    [Test]
    public void GetHeroShouldReturnNullWhenHeroIsNotFound()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivan", 999);
        repo.Create(hero);

        var resultHero = repo.GetHero("DrAGAN");

        Assert.AreEqual(null, resultHero);
    }

    [Test]
    public void HeroesShouldReturnCollectionCorrectly()
    {
        var repo = new HeroRepository();
        var hero = new Hero("Ivan", 999);
        repo.Create(hero);

        var collection = repo.Heroes;

        Assert.AreEqual(1, collection.Count);
    }
}