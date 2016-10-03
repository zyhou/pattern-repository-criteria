# Exemple d'architecture d'accès aux données.

Le but est d'isoler la couche d'accès aux données de toutes dépendances, de pouvoir réutiliser le projet dans d'autres solutions.

On peut très facilement appeler le projet AccessData dans d'autres produits (un site web, une application mobile, etc...).   
AccessData est juste lié à IAccessDATA, on a juste des interfaces. Ce qui permet de définir des contracts pour les modèles qui vont appeler les méthodes d'accès aux données.   
Le contexte est injecté aux plus haut niveaux de l'application, ce qu'il fait que l'on peut changer de SGDB à tout moment. 

**Ce qui est vraiment intéressant dans cette architecture, ce sont les critères de filtrage et la création de modèles.**

<a href="https://zyhou.github.io/2016/architecture-acces-aux-donnees/" target="_blank">Pour en savoir plus, rendez-vous sur mon blog.</a>