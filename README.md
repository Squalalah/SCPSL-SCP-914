# SCPSL-SCP-914

--------------

TRADUCTION FRANCAISE

**Description**

SCPSL-SCP-914 vous permet de modifier les recettes de la machine sur votre serveur.

# Installation

- Placez le fichier "914recipes.dll" dans le dossier "sm_plugins" de votre serveur
- Lancez le serveur au moins une fois afin de charger la configuration du SCP-914
- Enjoy !

# Fonctionnement

Une fois le serveur lancé, un fichier "squal_plugins_conf/914recipes.txt" va apparaitre dans la racine du serveur.
Celui-ci va vous permettre d'ajouter/retirer des objets à obtenir par conversion selon l'objet mis en INTAKE et le paramètre choisi.

**Exemples**

Les 5 configurations de la carte du Consierge dans le fichier "914recipes.txt" :

1. JANITOR_KEYCARD-ROUGH:NULL,
2. JANITOR_KEYCARD-COARSE:NULL,
3. JANITOR_KEYCARD-ONE_TO_ONE:ZONE_MANAGER_KEYCARD,
4. JANITOR_KEYCARD-FINE:SCIENTIST_KEYCARD,
5. JANITOR_KEYCARD-VERY_FINE:JANITOR_KEYCARD,SCIENTIST_KEYCARD,MAJOR_SCIENTIST_KEYCARD,

Conçernant la première ligne :
- "JANITOR_KEYCARD" est le nom de l'objet
- "ROUGH" est le paramètre de 914
- "NULL" signifie que l'objet va disparaitre à la sortie de 914

Pour la troisième ligne :
- "JANITOR_KEYCARD" est le nom de l'objet
- "ONE_TO_ONE" est le paramètre de 914 (1:1)
- "ZONE_MANAGER_KEYCARD" signifie que "JANITOR_KEYCARD" va être converti en "ZONE_MANAGER_KEYCARD" si la carte est raffiné avec le paramètre "1:1"

Pour la cinquième ligne :

- "JANITOR_KEYCARD" est le nom de l'objet
- "VERY_FINE" est le paramètre de 914
- "JANITOR_KEYCARD","SCIENTIST_KEYCARD","MAJOR_SCIENTIST_KEYCARD" signifie que "JANITOR_KEYCARD" a une chance sur 3 de :
 
1. Rester telle qu'elle est
2. De devenir une "SCIENTIST_KEYCARD" 
3. De devenir "MAJOR_SCIENTIST_KEYCARD"

--------------
