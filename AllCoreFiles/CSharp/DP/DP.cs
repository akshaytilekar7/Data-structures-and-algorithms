// https://www.google.co.in/books/edition/Dynamic_Programming_for_Coding_Interview/P-jtDQAAQBAJ?hl=en&gbpv=1&dq=dynamic+programming+for+interviews+pdf&printsec=frontcover
// Dynamic Programming for Coding Interviews A Bottom-Up approach to problem solving


// discrete maths by rosen

// 22 23 holiday october
// 12 13 / 19 20 November DSA END
// DP
// 3 4 tree
// sorting


// master lop invariant method


/*

LCS 
    -   very good appli ca  tions
        -   Advance search in gmail
        -   DNA matching - monkey and man



x = x1 x2 ... xm
y = y1 y2 ....yn

x is LCS of y if there exist k , 1 <= k <= n
            such that k+m <=n
            and
            xi exist in yk
            and xd exist in yk+m such that d <= 1 <= m 
            for all i, di < di+1  i <= x <= m  
            

void lcs( int* X, int* Y, int m, int n )
{
   int L[m+1][n+1];
   for (int i=0; i<=m; i++)
   {
     for (int j=0; j<=n; j++)
     {
       if (i == 0 || j == 0)
         L[i][j] = 0;
       else if (X[i-1] == Y[j-1])
         L[i][j] = L[i-1][j-1] + 1;
       else
         L[i][j] = find_max(L[i-1][j], L[i][j-1]);
     }
   }
 
   int index = L[m][n];
   int index2= L[m][n];
 
   int lcs[index];
  
   int i = m, j = n;
   while (i > 0 && j > 0)
   {
      if (X[i-1] == Y[j-1])
      {
          lcs[index-1] = X[i-1]; 
          i--; j--; index--;    

int find_max(int a, int b)
{
    return (a > b)? a : b;
}
  

int main()
{
 
  int m, n;
  
  scanf("%d", &m);
  scanf("%d", &n); 
  
  int* X = (int*)malloc(sizeof(int)*m);
  int* Y = (int*)malloc(sizeof(int)*n);
  
  for(int i=0; i<m; i++) 
  {
	scanf("%d", &X[i]);
	}
  for(int i=0; i<n; i++){
	scanf("%d", &Y[i]);
	}

  lcs(X, Y, m, n);
  return 0;
}
 

Last Character approach --===>>>>> Suppose, s1 and s2 are 2 strings and if last character of the string is same in both the strings, then lcs(s1, s2) = 1 + lcs(s1 - mth character, s2 - nth character) where m & n are the length of each string; …. but if m = 0 or n = 0 then return 0




char **lcs
call - (s, lenS1, 0m)
LCS(char* s1, int i, int iStart, char* s2, int j, int jStart)
{
   if(i == iStart) 
        return;

   if(j == jStart) 
        return;

    if(s1[iStart] == s2[jStart])
    {
        iStart++;
        jStart++;
    }
    else
    {
        lcs.insert (s1[0 .. iStart])
        jStart++;
        LCS(s1, i,iStart, j ,jStart) 
    }
}




int LCS(char X, char Y, int x, int y, int i, int j)
{
        if( i = 0 || j == 0) return 0; 
        if(X[i] == Y[j]) LCS(X ,Y ,x ,y , i-1, j-1)

        return Max(LCS(X, Y, x, y, i-1, j) , LCS(X, Y, x, y, i, j-1 ))
}



*/