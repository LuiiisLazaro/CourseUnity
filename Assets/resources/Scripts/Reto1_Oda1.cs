using UnityEngine;
using System.Collections;

//using UI
using UnityEngine.UI;

public class Reto1_Oda1 : MonoBehaviour {

	//declare var
	GameObject index, portada, reto1Obj, reto2Obj, reto3Obj, reto4Obj, retoFinalObj, projectObj, globo1, globo2, globo3;

	Button btnIniciar, btnReto1, btnReto2, btnReto3, btnReto4, btnRetoFinal, btnProyecto;

	//variables para el texto en los globos del reto 1 
	string text;
	Text label;
	bool animationStarted =false, b=false;
	float timeAnimation = 0.0f;
	float timeTotal = 0.0f;

	// Use this for initialization
	void Start () {
		index = this.transform.GetChild (0).gameObject;//obtiene index desde ODA1 desde los objetos en el panel de jerarquia
		portada = this.transform.GetChild (1).gameObject; //obteiene oprtada desde ODA1 

		reto1Obj = this.transform.FindChild ("Reto1").gameObject;
		reto2Obj = this.transform.FindChild ("Reto2").gameObject;
		reto3Obj = this.transform.FindChild ("Reto3").gameObject;
		reto4Obj = this.transform.FindChild ("Reto4").gameObject;
		retoFinalObj = this.transform.FindChild ("RetoFinal").gameObject;
		projectObj = this.transform.FindChild ("Proyecto").gameObject;

		globo1 = reto1Obj.transform.GetChild (0).FindChild ("globo1").gameObject;
		globo2 = reto1Obj.transform.GetChild (0).FindChild ("globo2").gameObject;
		globo3 = reto1Obj.transform.GetChild (0).FindChild ("globo3").gameObject;

		//obtiene el boton que se encuentra dentro de index buscandolo por el nombre;
		btnIniciar = index.transform.GetChild(0).FindChild ("btnAceptar").GetComponent<Button>(); // entra al canvas con el .getchild 0
		btnIniciar.onClick.AddListener (delegate {
			cerrarIndex();
		});

		btnReto1 = portada.transform.GetChild (0).FindChild ("btnReto1").GetComponent<Button> ();
		btnReto1.onClick.AddListener (delegate() {
			seleccionReto(btnReto1);	
		});

		btnReto2 = portada.transform.GetChild (0).FindChild ("btnReto2").GetComponent<Button> ();
		btnReto2.onClick.AddListener (delegate() {
			seleccionReto(btnReto2);
		});

		btnReto3 = portada.transform.GetChild (0).FindChild ("btnReto3").GetComponent<Button> ();
		btnReto3.onClick.AddListener (delegate() {
			seleccionReto(btnReto3);
		});

		btnReto4 = portada.transform.GetChild (0).FindChild ("btnReto4").GetComponent<Button> ();
		btnReto4.onClick.AddListener (delegate() {
			seleccionReto(btnReto4);
		});

		btnRetoFinal = portada.transform.GetChild (0).FindChild ("btnRetoFinal").GetComponent<Button> ();
		btnRetoFinal.onClick.AddListener (delegate() {
			seleccionReto(btnRetoFinal);	
		});

		btnProyecto = portada.transform.GetChild (0).FindChild ("btnProyecto").GetComponent<Button> ();
		btnProyecto.onClick.AddListener (delegate() {
			seleccionReto(btnProyecto);
		});
	}
	
	// Update is called once per frame
	void Update () {

		if (reto1Obj.activeInHierarchy && !b) {
			Invoke ("txtGlobo1",.2f);
			b=true;
		}



		//siempre al final de la animacion
		if (!animationStarted) {
			return;
		}
		timeAnimation -= Time.deltaTime;
		if (timeAnimation <= 0) {
			timeAnimation = 0;
		}

		label.text = text.Substring (0, (int)(((timeTotal - timeAnimation) * text.Length) / timeTotal));

	}

	//método para cambiar de index a portada
	void cerrarIndex(){
		index.SetActive (false);
		portada.SetActive (true);
	}

	void regresarIndex(){
		index.SetActive (true);
		portada.SetActive (false);
	}

	void seleccionReto(Button bot){
		portada.SetActive (false);
		if (bot.name == "btnReto1") {
			print ("reto1");
			reto1Obj.SetActive (true);
		} else if (bot.name == "btnReto2") {
			print ("reto2");
			reto2Obj.SetActive (true);
		} else if(bot.name == "btnReto3") {
			print ("reto3");
			reto3Obj.SetActive (true);
		} else if(bot.name == "btnReto4") {
			print ("reto4");
			reto4Obj.SetActive (true);
		} else if(bot.name == "btnRetoFinal") {
			print ("retoFinal");
			retoFinalObj.SetActive (true);
		} else if(bot.name == "btnProyecto") {
			print ("Proyecto");
			projectObj.SetActive (true);
		}	
	}

	void txtGlobo1(){
		globo1.SetActive (true);
		label = globo1.transform.GetChild (0).GetComponent<Text> ();
		Invoke ("txtGlobo2",5f);
		animatedString (4f, "!Oh qué bonita tortuga, ¿puedo llevármela a casa?");
	}

	void txtGlobo2(){
		globo2.SetActive (true);
		label = globo2.transform.GetChild (0).GetComponent<Text> ();
		Invoke ("txtGlobo3", 6f);
		animatedString (4f, "No, hija, no sería bueno sacarla de su ecosistema.");

	}

	void txtGlobo3(){
		globo3.SetActive (true);
		label = globo3.transform.GetChild (0).GetComponent<Text> ();
		Invoke ("abrirPopInicio", 6f);
		animatedString (4f, "¿Qué es un ecosistema?");
	}

	public void animatedString (float time, string t){
		text = t;
		timeAnimation = time;
		timeTotal = timeAnimation;
		animationStarted = true;
	}
}
