using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{ 
   Transform tr;

   private void Awake()
   {
      tr = GetComponent<Transform>();
   }

   private void Update()
   {
      tr.position += new Vector3(1.5f, 0f,0f) * Time.deltaTime;
   }

   
}
