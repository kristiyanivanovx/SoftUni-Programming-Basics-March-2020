create database VS

use VS

CREATE TABLE Recipes
(
	RecipeId int primary key identity not null,
	[Name] varchar(50) not null,
	[Description] varchar(50),
)

CREATE TABLE Ingredients
(
	IngredientId int primary key identity not null,
	[Name] varchar(150) not null,
)

create table RecipesIngredients
(
	RecipeId int,
	IngredientId int

	constraint PK_Recipes_Ingredients primary key (RecipeId, IngredientId),
	constraint FK_Recipes foreign key (RecipeId) references Recipes(RecipeId),
	constraint FK_Ingredients foreign key (IngredientId) references Ingredients(IngredientId)
)