using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FigClass : MonoBehaviour{
    int[] colors;
    int [,,] figures;
    int x;
    int y;
    int[] razmer; 
    int FigIndex;
    int col;

    int[,] figura;
    public FigClass(){

        colors =  new int[7] {0 ,1, 2, 3, 4, 5, 6};
        razmer=new int[7] {3,4, 3, 3, 3, 3, 4};
        
        figures = new int[7,4,4]{
            {{0, 1, 1, 0},
             {0, 1, 0, 0},
             {0, 1, 0, 0},
             {0, 0, 0, 0}},                                                                                                                                                                               
                                                                                                                                                                               
            {{0, 1, 0, 0},                                                                                                                                                                               
             {0, 1, 0, 0},                                                                                                                                                                               
             {0, 1, 0, 0},                                                                                                                                                                               
             {0, 1, 0, 0}},                                                                                                                                                                               
                                                                                                                                                                               
            {{0, 1, 0, 0},                                                                                                                                                                               
             {0, 1, 1, 0},                                                                                                                                                                               
             {0, 1, 0, 0},                                                                                                                                                                               
             {0, 0, 0, 0}},                                                                                                                                                                               
                                                                                                                                                                                        
            {{0, 1, 1, 0},                                                                                                                                                                               
             {1, 1, 0, 0},                                                                                                                                                                               
             {0, 0, 0, 0},                                                                                                                                                                               
             {0, 0, 0, 0}},                                                                                                                                                                               

            {{1, 1, 0, 0},
             {0, 1, 1, 0},
             {0, 0, 0, 0},
             {0, 0, 0, 0}},        

            {{1, 1, 0, 0},
             {0, 1, 0, 0},
             {0, 1, 0, 0},
             {0, 0, 0, 0}},        

            {{0, 0, 0, 0},
             {0, 1, 1, 0},
             {0, 1, 1, 0},
             {0, 0, 0, 0}}                       
        };
        
        x=6;
        y=0;
        FigIndex=Random.Range(0, 7);
        col=colors[FigIndex];
        figura = GetRow(figures, FigIndex);
        Array[,] GetRow<Array>(Array[,,] matrix_in, int layer) {
            Array[,] matrix_out = new Array[matrix_in.GetLength(1), matrix_in.GetLength(2)];
            for (int i = 0; i < matrix_in.GetLength(1); i++) {
                for (int j = 0; j < matrix_in.GetLength(2); j++){

                    matrix_out[i, j] = matrix_in[layer, i, j]; 
                }
            }
            return matrix_out;
        }

    }
    public void TurnFig(){
        int[,] tmp_fig = new int[4,4];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++){
                tmp_fig[i,j]=figura[i,j];

            }
        }
        
        if(razmer[FigIndex]==4){
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++){

                    figura[j, ((4-i)-1)] = tmp_fig  [i, j];
                    
                }
            }
        }
        else{
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++){

                    figura[j, (3-i)-1] = tmp_fig[i, j];
                    
                }
            }
        }

        
    }
    public int FigColor(){
        return col;     
    }       

    public int[,] GetFig(){
        return figura;
    }

    public int Getrazm(){
        return razmer[FigIndex];
    }
    public int Getind(){
        return FigIndex;
    }
    public int Xpos(int scale=0){
        x+=scale;
        return x;
    }

    public int Ypos(int scale=0){
        y+=scale;
        return y;
    }




















}
public class GameScreenClass : MonoBehaviour{
    bool l;                                                              
    bool r;                                                              
    bool n;   
    int tmpt=0;                                                      
    bool rot;                                                             
    public GameScreenClass(GameObject[,] cubs){                                                              

        
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                cubs[i,j].GetComponent<MeshRenderer>().enabled=false;
            }
        }                                                  
        //demon();                                                     
        l=false;                                                              
        r=false;                                                              
        n=false;                                                              
        rot=false;                                                             
    }                     
    public void Camp(){  
        tmpt+=1;
    }
    public void Cam(GameObject x){   
 
        x.transform.RotateAround(new Vector3(6.0f, 11.0f, 0.0f), Vector3.up, 3);







    }    
    public void DrawGrid(GameObject xp,GameObject yp){
        for (int i = 0; i < 22; i++)
        {
            Instantiate(xp).transform.position= new Vector3(6f,i+0.5f,0.3f);                                                              
        }
        for (int j = 0; j < 13; j++)
        {
            Instantiate(yp).transform.position= new Vector3(j+0.5f,10.5f,0.3f);         
        }    
    }

    public void Rect(int x, int y, int[,] color  ,GameObject [,] matrix_in,Material[] mat){
        //pygame.draw.rect(self.gameScreen, colors[color], (x*self.SizeCell+2, y*self.SizeCell+2, self.SizeCell-4, self.SizeCell-4))
        matrix_in[x,y].GetComponent<MeshRenderer>().enabled = true;
        //        colors =  new string[7] {"White", "Yello", "Green", "Red", "Orang", "Blue", "Pink"};
        
        matrix_in[x,y].GetComponent<MeshRenderer>().material=mat[color[x,21-y]];
        
                                                              
    }                       
    public void Write(int[,] matrix_in, int[,] mass ,GameObject[,] matrix_gm ,Material[] mat, int[,] matrix_in2, int[,] mass2 ,GameObject[,] matrix_gm2 ){
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                if(matrix_in[i,j]==1){
                    
                    Rect(i, 21-j, mass,matrix_gm, mat);
                }
                else{
                    matrix_gm[i,21-j].GetComponent<MeshRenderer>().enabled = false; 
                }

            }
        }

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                if(matrix_in2[i,j]==1){
                    
                    Rect(i, 21-j, mass2,matrix_gm2, mat);
                }
                else{
                    matrix_gm2[i,21-j].GetComponent<MeshRenderer>().enabled = false; 
                }

            }
        }
    }                                                             
}                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
                                                              
public class GameZoneClass : MonoBehaviour{                                                              
    public int[,] Zone = new int[13,22];                                                              
    public int[,] ZoneColor = new int[13,22];   
                                                  
    public GameZoneClass(){                                                              
      for (int i = 0; i < 13; i++){                                                              
        for (int j = 0; j < 22; j++)                                                              
        {                                                              
            Zone[i,j]=0;                                                              
            ZoneColor[i,j]=0;                                                              
                                                              
        }                                                              
      }                                                              
    }                                                              
    public bool CheckPaste( int x, int y,int[,] fig_in){                                                              
        int[,] ZoneForCheckPaste=new int[13,22];                                                              
        for(int i = 0; i < 13; i++){                                                              
          for (int j = 0; j < 22; j++)                                                              
          {                                                              
              ZoneForCheckPaste[i,j] = Zone[i,j];                                                              
          }                                                              
        }                                                                
                                                                       
        for(int i = 0; i < 4; i++){                                                              
            for (int j = 0; j < 4; j++)                                                              
            {                                                              
                if(x+i<13 && y+j<22 && x+i >-1 && y+j >-1){                                                              
                    ZoneForCheckPaste[x+i, y+j]+=fig_in[i, j];                                                              
                    if(ZoneForCheckPaste[x+i, y+j]==2){ return false;}                                                              
                }                                                              
                else{                                                              
                    if(fig_in[i,j]==1){                                                              
                        return false;                                                              
                    }                                                              
                }                                                              
                                                              
            }                                                              
        }                                                              
        return true;                                                              
    }                                                              
                                                              
    public bool CheckTurn(int x,int y,int[,] fig_in,int a,int b){                                                              
        int[,] ZoneForCheckTurn=new int[13,22];                                                              
        for(int i = 0; i < 13; i++){                                                              
          for (int j = 0; j < 22; j++)                                                              
          {                                                              
              ZoneForCheckTurn[i,j] = Zone[i,j];                                                              
          }                                                              
        }       
        if(a==4){                                                         
            for(int i = 0; i < 4; i++){                                                              
                for (int j = 0; j < 4; j++){                                                              
                    if(x+j<13 && y+(4-i)-1<22 && x+j >-1 && y+(4-i)-1 >-1 ){   
                                                                             
                        ZoneForCheckTurn[x+j, y+(4-i)-1]+=fig_in[ (4-i)-1,j];                                                              
                        if(ZoneForCheckTurn[x+j, y+(4-i)-1]==2){ return false;}                                                              
                                                              
                    }                                                              
                    else{                                                              
                                                                                  
                        if(fig_in[ (4-i)-1,j]==1){                                                              
                                                              
                            return false;                                                              
                        }                                                              
                    }                                                              
                }                                                              
            }    
        }   
        else{
            for(int i = 0; i < 3; i++){                                                              
                for (int j = 0; j < 3; j++){                                                              
                    if(x+j<13 && y+(3-i)-1<22 && x+j >-1 && y+(3-i)-1 >-1 ){   
                                                                             
                        ZoneForCheckTurn[x+j, y+(3-i)-1]+=fig_in[ (3-i)-1,j];                                                              
                        if(ZoneForCheckTurn[x+j, y+(3-i)-1]==2){ return false;}                                                              
                                                              
                    }                                                              
                    else{                                                              
                                                                                  
                        if(fig_in[ (3-i)-1,j]==1){                                                              
                                                              
                            return false;                                                              
                        }                                                              
                    }                                                              
                }                                                              
            }   
        }                                                       
                                                              
        return true;                                                              
                                                                  
    }                                                              
                                                              
    public bool CheckString(int y){                                                              
        int tmp=0;                                                              
        for(int i = 0; i < 13; i++){                                                              
            tmp+=Zone[i,y];                                                              
        }                                                              
                                                              
        return tmp == 13;                                                              
                                                                  
    }                                                              
                                                                  
    public void DelString(int y,GameObject vz,int g){                                                              
                                                              
        for(int i = 0; i < 13; i++){                                                              
            Zone[i,y]=0;                                                              
            ZoneColor[i,y]=0;
            Instantiate(vz).transform.position= new Vector3(i,21-y,g);                                                                 
        }                                                              
        for(int i = 12; i >-1; i--){                                                              
            for (int j = 22; j > -1; j--){                                                              
                if (j<=y && j!=0){                                                              
                    Zone[i,j]=Zone[i,j-1];                                                              
                    ZoneColor[i,j]=ZoneColor[i,j-1];                                                              
                }                                                              
            }                                                              
        }                                                            
                                                              
    }                                                              
                                                              
                                                              
    public void Set(int x, int y, int[,] fig_in,int direct=1,int color=0){                                                              
        for(int i = 0; i < 4; i++){                                                              
            for (int j = 0; j < 4; j++){                                                              
                if(x+i<13 && y+j<22 && fig_in[i, j]==1){                                                              
                    if(direct==1){                                                              
                        ZoneColor[x+i, y+j] = color;                                                 
                        Zone[x+i, y+j] = fig_in[i, j];                                               
                    }                                                                                
                    else{                                                                            
                        Zone[x+i, y+j] -= fig_in[i, j];                                              
                        ZoneColor[x+i, y+j] = 0;                                               
                    }                                                                                
                }                                                                                    
            }                                                                                        
        }                                                                                            
    }                                                                                                
    public int[,] GetGameZone(){                                                                     
        return Zone;                                                                                 
    }                                                                                                
    public int[,]  GetZoneColor(){                                                                
        return ZoneColor;                                                                            
    }                                                                                                
                                                             
}                                                              
                                                              
                                                              
                                                              
                                                              
public class Game : MonoBehaviour                                                              
{                    
    FigClass Figsled;   
    public GameObject[,] ifig = new GameObject[4,4];    
    public GameObject[,] zfig = new GameObject[4,4];               
    public Text text;                     
    public GameObject x;         
    public GameObject palx;
    public GameObject vzru;
    public GameObject paly;  
    public AudioClip[] m;
    public AudioSource n;
    public GameObject img;                                                   
    public GameObject[,] mass = new GameObject[13,22];   
    public GameObject[,] mass2 = new GameObject[13,22];                                                            
    public Material[] material = new Material[7];    
    GameZoneClass zone; 
    GameScreenClass screen; 
    FigClass Fig;    
    GameZoneClass zone2; 
    GameScreenClass screen2; 
    int trig=-1;
    float t=0.8f;  
    float tmp=0;
    int r=0;
    int vid=1;
    int yd=0;
    public Material skybox1;
    public Material skybox2;
    int sk=1;
    int ocki=0;
    int paloc=0;
    int star=0;
    int otp=0;
    int rotx;
    int roty;
    public void camer(){
        if(trig==-1){
          trig+=180;
          vid*=-1;
        }
        

        

        
    }        
    void Start()             
    {           
        //Input.GetAxis("Horizontal");
        rotx= (int)Random.Range(-3, 3);
        roty= (int)Random.Range(-3, 3);

        
        
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                mass[i,j]=Instantiate(x);  
                mass[i,j].transform.position= new Vector3(i,j,0);   
                mass2[i,j]=Instantiate(x);  
                mass2[i,j].transform.position= new Vector3(i,j,1);   
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                ifig[i,j]=Instantiate(x);  
                ifig[i,j].transform.position= new Vector3(i+11+6.5f,j+10,0);   
                zfig[i,j]=Instantiate(x);  
                zfig[i,j].transform.position= new Vector3(i-13+6.5f,j+10,0);                   
            }
        }
        zone = new GameZoneClass(); 
        screen = new GameScreenClass(mass); 
        Fig = new FigClass();  
        Figsled = new FigClass();      
        zone2 = new GameZoneClass(); 
        screen2 = new GameScreenClass(mass2); 

  
        


        screen.DrawGrid(palx,paly);


            








        
        StartCoroutine(MyUpdate2());      
        StartCoroutine(MyUpdate());                   
                                                              
    }  
    IEnumerator MyUpdate2 (){
        while (true) {     
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(vid==1){
                        if(Figsled.GetFig()[i,j]==1){
                            ifig[i,j].GetComponent<MeshRenderer>().enabled = true;

                            ifig[i,j].GetComponent<MeshRenderer>().material=material[Figsled.FigColor()];
                        }
                        else{
                            ifig[i,j].GetComponent<MeshRenderer>().enabled = false;
                        }
                        if(Figsled.Getrazm()==4){
                          ifig[i,j].transform.RotateAround(new Vector3(13.5f+6.5f, 11.0f, 0.0f), Vector3.up,rotx);
                          ifig[i,j].transform.RotateAround(new Vector3(13.5f+6.5f, 11.0f, 0.0f), Vector3.right,  roty);
                        }
                        if(Figsled.Getrazm()==3){
                          ifig[i,j].transform.RotateAround(new Vector3(13+6.5f, 11.0f, 0.0f), Vector3.up, rotx);
                          ifig[i,j].transform.RotateAround(new Vector3(13+6.5f, 11.0f, 0.0f), Vector3.right,   roty);
                        }   
                    } 
                    else{
                        ifig[i,j].GetComponent<MeshRenderer>().enabled = false;
                    }
                    if(vid==-1){
                        if(Figsled.GetFig()[i,j]==1){
                            zfig[i,j].GetComponent<MeshRenderer>().enabled = true;
            
                            zfig[i,j].GetComponent<MeshRenderer>().material=material[Figsled.FigColor()];
                        }
                        else{
                            zfig[i,j].GetComponent<MeshRenderer>().enabled = false;
                        }
                        if(Figsled.Getrazm()==4){
                          zfig[i,j].transform.RotateAround(new Vector3(-11.5f+6.5f, 11.0f, 0.0f), Vector3.up,rotx);
                          zfig[i,j].transform.RotateAround(new Vector3(-11.5f+6.5f, 11.0f, 0.0f), Vector3.right,  roty);
                        }
                        if(Figsled.Getrazm()==3){
                          zfig[i,j].transform.RotateAround(new Vector3(-11+6.5f, 11.0f, 0.0f), Vector3.up, rotx);
                          zfig[i,j].transform.RotateAround(new Vector3(-11+6.5f, 11.0f, 0.0f), Vector3.right,   roty);
                        }   
                    } 
                    else{
                        zfig[i,j].GetComponent<MeshRenderer>().enabled = false;
                    }                                   


                }
            }


            if(Input.GetAxis("Cancel")==1) {
                Application.Quit();
            } 
            if(Input.GetAxis("Vertical")==0){
                otp=1;
            }
            print(otp);
            text.text="score: "+ ocki;
            if((Input.GetAxis("Fire1")==1 && vid==-1 && zone.CheckPaste(Fig.Xpos(),Fig.Ypos(),Fig.GetFig())) || 
            (Input.GetAxis("Fire1")==1 && vid==1 && zone2.CheckPaste(Fig.Xpos(),Fig.Ypos(),Fig.GetFig()) )){
                camer();
                if(Input.GetAxis("Fire1")==1 && vid==-1){
                   zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),-1, Fig.FigColor());
                   zone2.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), 1, Fig.FigColor());   
                }
                if(Input.GetAxis("Fire1")==1 && vid==1){
                    zone2.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),-1, Fig.FigColor());
                    zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), 1, Fig.FigColor());   
                }
                
            }

            if(vid==1){
                zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), 1, Fig.FigColor());
            }
            else{
                zone2.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), 1, Fig.FigColor());   
            }         
            screen.Write(zone.GetGameZone(),zone.GetZoneColor(),mass,material,zone2.GetGameZone(),zone2.GetZoneColor(),mass2);
            if(vid==1){
                zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), -1, Fig.FigColor());
            }
            else{
                zone2.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), -1, Fig.FigColor());   
            }    

            if(Input.GetAxis("Vertical")<0){
                t=0.1f;
            }
            else{
                t=0.6f;
            }
            if(vid==1 && Input.GetAxis("Horizontal")<0 && zone.CheckPaste(Fig.Xpos()-1,Fig.Ypos(),Fig.GetFig())){
              Fig.Xpos(-1);
            }
            if(vid==1 && Input.GetAxis("Horizontal")>0 && zone.CheckPaste(Fig.Xpos()+1,Fig.Ypos(),Fig.GetFig())){
              Fig.Xpos(1);
            }      
            if(otp==1 && vid==1 && Input.GetAxis("Vertical")>0 && zone.CheckTurn(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),Fig.Getrazm(),Fig.Getind())){
              Fig.TurnFig();
              otp=0;              
            }

            if(vid==-1 && Input.GetAxis("Horizontal")>0 && zone2.CheckPaste(Fig.Xpos()-1,Fig.Ypos(),Fig.GetFig())){
              Fig.Xpos(-1);
            }
            if(vid==-1 && Input.GetAxis("Horizontal")<0 && zone2.CheckPaste(Fig.Xpos()+1,Fig.Ypos(),Fig.GetFig())){
              Fig.Xpos(1);
            }      
            if(otp==1 && vid==-1 && Input.GetAxis("Vertical")>0 && zone2.CheckTurn(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),Fig.Getrazm(),Fig.Getind())){
              Fig.TurnFig();
              otp=0;
            }

            for (int j = 0; j < 22; j++){                                                                  
              if(zone.CheckString(j)==true && zone2.CheckString(j)==true){                                                                    
                zone.DelString(j,vzru,0);          
                zone2.DelString(j,vzru,1);  
                n.clip=m[Random.Range(0, 12)];
                n.Play();
                paloc+=1;                                                                                        
              }                                                              
            } 
            if(paloc==1){
                ocki+=100;
            }
            if(paloc==2){
                ocki+=300;
            }
            if(paloc==3){
                ocki+=700;
            }
            if(paloc==4){
                ocki+=1500;
            }
            paloc=0;
            for (int i = 0; i < 10; i++)
            {
                
                if(trig>=0){
                    screen.Cam(gameObject);
                    trig-=3;
                    if(trig==89){
                        if(sk==1){
                            RenderSettings.skybox = skybox1;
                            sk*=-1;
                        }
                        else if(sk==-1){
                            RenderSettings.skybox = skybox2;
                            sk*=-1;
                        }        
                    }
                }
            }
            yield return new WaitForSeconds(0.08f);   
            if(vid==1 &&  zone.CheckPaste(Fig.Xpos(),Fig.Ypos()+1,Fig.GetFig()) && yd>0){
                yd-=1;
                Fig.Ypos(1);
            }
            else if(vid==1 && yd>0){
                zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),1, Fig.FigColor());
                Fig=Figsled;
                Figsled = new FigClass();  
                t=0.6f;     
                rotx= Random.Range(-3, 3);
                roty= Random.Range(-3, 3);                
            }
            if(vid==-1 &&  zone2.CheckPaste(Fig.Xpos(),Fig.Ypos()+1,Fig.GetFig()) && yd>0){
                yd-=1;
                Fig.Ypos(1);
            }
            else if(vid<0 && yd>0){
                zone2.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),1, Fig.FigColor());
                Fig=Figsled;
                Figsled = new FigClass();  
                rotx= Random.Range(-3, 3);
                roty= Random.Range(-3, 3);
                t=0.6f;   
            }












        }
    }                                    
    IEnumerator MyUpdate (){
        while (true) {




            yield return new WaitForSeconds(t);   

            yd+=1;

            r+=1;

            yield return null;
        }





    }                                                         
    // Start is called before the first frame update                                                              
                             
                                                              
    // Update is called once per frame                                                              
    void Update()                                                              
    {                                                              
        
        if(star==0 &&(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)){
            Destroy(img,0.1f);
            star=1;
            n.clip=m[Random.Range(0, 12)];
            n.Play();

        }
        else if(star==0){
            if(Fig.Ypos()>0){
                Fig.Ypos(-1);
            }


        }



                                                                  
    }                                                              
}                                                              
                                                                            