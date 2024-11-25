using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace DatabaseExtended.Tests;

public class PersonTests
{
    private static readonly (char Begin, int Length)[] CharacterGroups = { ('a', 26), ('A', 26), ('0', 10) };

    private Person personInstance;
    private long personId;
    private string personName;

    [SetUp]
    public void Setup()
    {
        personId = Random.Shared.NextInt64();
        personName = GenerateRandomString();

        personInstance = new Person(personId, personName);
    }

    

    [Test]

    public void PersonInitialisedShouldNotBeNull()
    {
        Person person = new Person(Random.Shared.NextInt64(),GenerateRandomString());

        Assert.That(person,Is.Not.Null);
        Assert.That(person.Id,Is.Not.Null);
        Assert.That(person.UserName, Is.Not.Null);
    }

                                    

    private static string GenerateRandomString()
    {
        char[] content = new char[Random.Shared.Next(5, 30)];

        for (int i = 0; i < content.Length; i++)
        {
            int randomGroupIndex = Random.Shared.Next(CharacterGroups.Length);
            content[i] = (char)(CharacterGroups[randomGroupIndex].Begin + Random.Shared.Next(CharacterGroups[randomGroupIndex].Length));
        }

        return new string(content);
    }
}
