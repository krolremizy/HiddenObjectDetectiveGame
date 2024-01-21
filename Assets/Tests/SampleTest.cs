using NUnit.Framework;
using TMPro;
using UnityEngine;

public class SampleTest
{
    [Test]
    public void Item_PickedUp_SetsWasFoundTrue()
    {
        // Arrange
        GameObject itemObject = new GameObject();
        Item item = itemObject.AddComponent<Item>();

        // Act
        item.PickedUp();

        // Assert
        Assert.IsTrue(item.wasFound);
    }

    [Test]
    public void Item_PickedUp_InvokesOnPickUpEvent()
    {
        // Arrange
        GameObject itemObject = new GameObject();
        Item item = itemObject.AddComponent<Item>();
        bool eventInvoked = false;
        item.OnPickUp += () => eventInvoked = true;

        // Act
        item.PickedUp();

        // Assert
        Assert.IsTrue(eventInvoked);
    }

}
