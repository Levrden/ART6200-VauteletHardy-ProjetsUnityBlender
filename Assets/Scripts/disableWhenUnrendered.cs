using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

/*Ce script ne peut fonctionner !
j'utiliser ici la booléenne Renderer.isVisible qui dépend du renderer lui-même
Ce qui fait que une fois que les objets sont désactivés, je ne peux pas savoir s'ils arrivent dans mon champs de vision.
La prochaine tentative va s'appuyer sur les fonctions de visibilité de Unity qui sont à priori faites pour ça : https://docs.unity3d.com/Manual/OcclusionCulling.html
*/

public class disableWhenUnrendered : MonoBehaviour
{
    //On créé une liste qui va contenir tous les enfants du gameObject
    public List<GameObject> tag_targets = new List<GameObject>();
    
            //On créé une fonction qui va remplir la liste avec tous les enfants d'un parent qui ont un tag particulier
            private void AddDescendantsWithTag(Transform parent, string tag, List<GameObject> list)
        {
            foreach (Transform child in parent)             //Pour chaque enfant du parent
            {
                if (child.gameObject.tag == tag)            //Si son tag correspond
                {
                    list.Add(child.gameObject);             //Alors on l'ajoute à la liste
                }
                //AddDescendantsWithTag(child, tag, list);    //On recommence avec tous les enfants des enfants
            }
        }
     
        void Start()
        {
            AddDescendantsWithTag(transform, "Targets", tag_targets);   //Au début on remplit la liste
            hideAll();                                                  //Et on cache tous ses éléments
        }

        void Update(){
            enableIfVisible();                                          //A chaque frame on le rend visible s'il est dans le champ de la camera
        }

        void hideAll(){
            for(int i = 0; i<tag_targets.Count;i++){                    //On prend tous les éléments de la liste
            tag_targets[i].GetComponent<Renderer>().enabled = false;    //On les désactive
            }
        }

        void enableIfVisible(){
            for(int i = 0; i<tag_targets.Count;i++){                            //Pour chacun des éléments de la liste
                if(tag_targets[i].GetComponent<Renderer>().isVisible){          //S'il est visible
                    tag_targets[i].GetComponent<Renderer>().enabled = true;     //On le rend visible
            }else{tag_targets[i].GetComponent<Renderer>().enabled = false;}     //Sinon on le rend invisible
            }
        }
}
