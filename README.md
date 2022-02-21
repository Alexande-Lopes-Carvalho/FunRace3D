# FunRace3D

Réalisation de l’exercice : 8h20 

Le projet a été découpé en trois versions de la manière suivante : 
 - Une version réalisée en 5 heures contenant tout ce qui est essentiel au jeu (voir commit : "Résultat a 5h de développement"). 
 - Une version réalisée en 8 heures rajoutant une UI, un nouveau type d'ennemi (garde) et deux segments de niveau appelés Level Component, (voir commit : "Result after 7h and 53 min").
 - Une version rajoutant des éléments esthétiques pour le jeu (voir commit : "Result after 8h 20 min").
 
Les points qui m'ont posé problème : 

 - Mauvaise évaluation du temps requis pour ajouter toutes les features que j’ai souhaité implémenter.
   J'aurais dû partir sur un modèle plus simple et ajouter des features en fonction du temps restant.

Les points que je pense améliorer et comment :

 - Amélioration de la classe Path, plus précisément sa méthode pour générer des courbes de bézier. 
   Pour l'instant, il génère des courbes par groupes de 3 points => Il faut donc pousser l'algorithme 
   afin qu'il crée une courbe en prenant tous les points en considération.

 - Les éléments du décor qui obstruent la vue : (arbres)
   Création d'un shader pour voir au travers.
   
 - Game Design :
   Jeu beaucoup trop facile et lent :
	 => Changement des patterns de déplacement des gardes sur certains segments.
	 => Modification des segments de niveaux (certains sont trop grands, ce qui rend le gameplay lent).
	 => Accélération des ennemis.
   
 - Ajout de plusieurs de segments de niveau, voici quelques idées :
    - Segment avec un arbre qui tombe puis disparaît, (avertissement du joueur avant de tomber).
	- Segments à l'intérieur du bâtiment.
	- Segment avec un garde qui dort (le joueur doit se rapprocher à tâtons pour ne pas le réveiller).
	- Segment avec un labyrinthe (générer procéduralement ou pas) (uniquement un chemin vers la sortie)
	   => Ajoute des phases de réflexion pour le joueur qui doit deviner où le personnage va aller en progressant
	- Segment avec des gardes qui tirent au fusil d'assaut, le joueur doit esquiver des balles
	
 - Permettre la modification de l'angle et la distance de vue des gardes directement dans l'éditeur avec des "Handle".
	
 - Si l'on ne considère que le niveau généré procéduralement, nous pouvons penser à ajouter un système 
   de scoring qui permet d'indiquer à quel point le joueur est arrivé loin.
 
Ce que je ferais si je dois pousser le projet un cran plus loin :

 - Création d'une charte graphique spécialement pour le jeu. En effet, j'ai été limité par les assets que j'ai 
   utilisés (asset que j'ai réalisé spécialement pour un précédent projet voir https://alexandrelopescarvalho.itch.io/wolfangurd). 
   Notamment lors de la conception de segments de niveau, où je n'ai trouvé que deux types d'ennemis qui assuraient une cohérence.

Ce que j'en ai pensé :

Une meilleure gestion de mon temps, m’aurait permis de produire un travail de qualité supérieure, notamment 
en poussant la réflexion sur les segments, ce qui aurait évité d'induire un gameplay lent.