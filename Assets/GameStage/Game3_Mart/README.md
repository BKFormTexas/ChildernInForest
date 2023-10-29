# mart game
***
  - Writing language: C#
***
  -Update Log
     - 21.07.08: Code writing completed
     - 21.07.09: If the answer is incorrect or correct, an OX image is displayed to make it more lively.
     - 21.07.20: Encoding format modified to UTF8
     - 21.07.21: Added voice function in case of correct or incorrect answer

***
  - Running screen and contents

![Mart Game](https://user-images.githubusercontent.com/37494407/126114297-dc1d8758-c20f-4b8c-abe8-846a56ab6482.png)

     - The item desired by the protagonist is randomly selected and displayed in a speech bubble.
     - This is a game where the main character puts the items he wants into the cart.
    
![Mart

     - If the main character contains an unwanted item, an X appears and the item returns to its original place.
![Marto](https://user-images.githubusercontent.com/37494407/126114600-a052aeee-68ed-4f92-b45a-e5f0c8dfb5b7.png)

     - When the protagonist puts an item into the cart, an O sign appears and the item disappears.
     - Afterwards, the remaining items are randomly replaced.
    
    
***

- Mart configuration information
   -Image
     - Save images used in the scene
   -Scripts
     - Mart_ControlOX.cs: Script that displays OX in case of a correct or incorrect answer
     - Mart_ControlUI.cs: Script that manages correct answers and randomly selects items from among the remaining items.
     - Mart_Kart.cs: Script related to cart object
     - Mart_MouseDrag.cs: Script that adds the drag function
     - Mart_RandomItem.cs: Script that displays the correct answer

***
