# FunRace3D

Temps pour réaliser l'exercice : 8h20m

Projet découpé en trois versions :
 - une version qui contient tout ce qui est essentiel au jeu faite en 5 heures de travail (voir commit : "Résultat a 5h de développement")
 - une version qui ajoute une UI, un nouveau type d'ennemi (garde) et deux segments de niveau (appelé Level Component) fait en 8 heures de travail (voir commit : "Result after 7h and 53 min")
 - une version qui ajoute des éléments esthétiques pour le jeu (voir commit : "Result after 8h 20 min")
 
Les points qui m'ont posé problème : 

 - J'ai mal évalué le temps requis pour l'ajout de toutes les features que je souhaitais implementer,
   j'aurais dû partir sur un modèle plus simple et ajouter des features en fonction du temps restant.

Les points que je pense améliorer et comment :

 - Amélioration de la classe Path, plus précisément sa méthode pour générer des courbes de bézier :
   Pour l'instant il génère des courbes par groupes de 3 points => pousser l'algorithme pour qu'il 
   crée une courbe en prenant tous les points en considération.
   
 - Les éléments du décor qui obstruent la vue : (arbres)
   Création d'un shader pour voir au travers.
   
 - Game Design :
   Jeu beaucoup trop facile et lent => changement des patterns de déplacement des gardes sur certains 
   segment, modification des segments de niveau (certains sont trop grands, ce qui rend le gameplay lent)
   accélération des ennemis.
   
 - Ajout de plus de segments de niveau, voici quelques idées que j'ai notées :
    - Segment avec un arbre qui tombe (puis disparrait), (avertissement du joueur avant de tomber)
	- Segments à l'intérieur de bâtiment
	- Segment avec un garde qui dort (le joueur doit se rapprocher à tâtons pour ne pas le réveiller)
	- Segment avec un labyrinthe (généré procéduralement ou pas) (uniquement un chemin vers la sortie), 
	  ajoute des phases de réflexion pour le joueur qui doit deviner où le personnage va aller en progressant
	- Segment avec des gardes qui tire au fusil d'assaut, le joueur doit esquiver des balles
	
 - Permettre la modification de l'angle de vue et la distance de vue des gardes directement dans l'éditeur avec des "Handle"
	
 - Si l'on ne considère que le niveau généré procéduralement, nous pouvons penser à ajouter un système de scoring
   qui permet d'indiquer à quel point le joueur est arrivé loin.
 
Ce que je ferais si je dois pousser le projet un cran plus loin :

 - Création d'une charte graphique spécialement pour le jeu, en effet j'ai été limité par les assets que j'ai utilisés (asset que j'ai 
   réaliser spécialement pour un précédent projet voir https://alexandrelopescarvalho.itch.io/wolfangurd).
   notamment lors de la conception de segments de niveau où je n'ai trouvé que deux types d'ennemi qui assurait une cohérence.   

Ce que j'en ai pensé :

Je pense que si j'aurais mieux géré mon temps j'aurais pu produire quelque chose de meilleur, notamment en poussant la réflexion sur les 
segments ce qui m'aurait évité d'induire un gameplay lent.
 