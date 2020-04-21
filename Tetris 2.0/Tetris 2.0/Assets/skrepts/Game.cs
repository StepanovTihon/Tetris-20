using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        FigIndex=Random.Range(0, 6);
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
                    print("a  " + ((4-i)-1));
                    figura[j, ((4-i)-1)] = tmp_fig  [i, j];
                    
                }
            }
        }
        else{
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++){
                    print("b  " + ((3-i)-1));
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
    public int[] Getrazm(){
        return razmer;
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
    public void Write(int[,] matrix_in, int[,] mass ,GameObject[,] matrix_gm ,Material[] mat){
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
                                                              
    public bool CheckTurn(int x,int y,int[,] fig_in,int[] a,int b){                                                              
        int[,] ZoneForCheckTurn=new int[13,22];                                                              
        for(int i = 0; i < 13; i++){                                                              
          for (int j = 0; j < 22; j++)                                                              
          {                                                              
              ZoneForCheckTurn[i,j] = Zone[i,j];                                                              
          }                                                              
        }       
        if(a[b]==4){                                                         
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
                                                                  
    public void DelString(int y){                                                              
                                                              
        for(int i = 0; i < 13; i++){                                                              
            Zone[i,y]=0;                                                              
            ZoneColor[i,y]=0;                                                              
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
    public void DelStrings(){                                                                        
      for (int j = 0; j < 22; j++){                                                                  
        if(CheckString(j)==true){                                                                    
          DelString(j);                                                                              
        }                                                              
      }                                                              
                                                              
    }                                                              
}                                                              
                                                              
                                                              
                                                              
                                                              
public class Game : MonoBehaviour                                                              
{                                                              
    public GameObject x;         
    public GameObject palx;
    public GameObject paly;                                                     
    public GameObject[,] mass = new GameObject[13,22];                                                              
    public Material[] material = new Material[7];    
    GameZoneClass zone; 
    GameScreenClass screen; 
    FigClass Fig;     
    int trig=-1;
    float t=0.8f;  
    float tmp=0;
    int r=0;

    public void camer(){
        trig=180;
    }        
    void Start()             
    {           
        //Input.GetAxis("Horizontal");

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 22; j++)
            {
                mass[i,j]=Instantiate(x);  
                mass[i,j].transform.position= new Vector3(i,j,0);   

            }
        }
        zone = new GameZoneClass(); 
        screen = new GameScreenClass(mass); 
        Fig = new FigClass();     
  


        screen.DrawGrid(palx,paly);


            








        
        StartCoroutine(MyUpdate2());      
        StartCoroutine(MyUpdate());                   
                                                              
    }  
    IEnumerator MyUpdate2 (){
        while (true) {        
            zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(), 1, Fig.FigColor());
            screen.Write(zone.GetGameZone(),zone.GetZoneColor(),mass,material);
            zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),-1, Fig.FigColor());



            if(Input.GetAxis("Vertical")<0){
                t=0.1f;
            }
            else{
                t=0.6f;
            }
            if(Input.GetAxis("Horizontal")<0 && zone.CheckPaste(Fig.Xpos()-1,Fig.Ypos(),Fig.GetFig())){
              Fig.Xpos(-1);
            }
            if(Input.GetAxis("Horizontal")>0 && zone.CheckPaste(Fig.Xpos()+1,Fig.Ypos(),Fig.GetFig())){
              Fig.Xpos(1);
            }      
            if(Input.GetAxis("Vertical")>0 && zone.CheckTurn(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),Fig.Getrazm(),Fig.Getind())){
                Fig.TurnFig();
            }


            zone.DelStrings();
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.0000000001f);   
                if(trig>=0){
                    screen.Cam(gameObject);
                    trig-=3;
                }
            }

            print(trig);










        }
    }                                    
    IEnumerator MyUpdate (){
        while (true) {




            yield return new WaitForSeconds(t);   
            if(zone.CheckPaste(Fig.Xpos(),Fig.Ypos()+1,Fig.GetFig())){
                Fig.Ypos(1);
            }
            else{
                zone.Set(Fig.Xpos(),Fig.Ypos(),Fig.GetFig(),1, Fig.FigColor());
                Fig = new FigClass();     
            }
            r+=1;
            if(r==2){
                camer();
                r=0;
            }
            yield return null;
        }





    }                                                         
    // Start is called before the first frame update                                                              
                             
                                                              
    // Update is called once per frame                                                              
    void Update()                                                              
    {                                                              
        




                                                                  
    }                                                              
}                                                              
                                                                            