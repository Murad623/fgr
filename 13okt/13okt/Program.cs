using _13okt.Classes;

Animal animal = new Animal();
Human human = new Human();
Mushroom mushroom = new Mushroom(false);
Plant plant = new Plant();

animal.Breathing("Animal");
human.Breathing("human");
mushroom.Breathing("mushroom");
plant.Breathing("plant");

human.Run();
animal.Run();