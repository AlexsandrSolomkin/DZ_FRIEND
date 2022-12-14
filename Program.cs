//	Задача:
//	Напишите метод вычисления расстояния от отрезка до точки.
//	Расстоянием от отрезка до точки называется расстояние от ближайшей точки отрезка до точки. Это либо расстояние 
// до точки от прямой, содержащей отрезок, либо расстояние до точки от одного из концов отрезка.

//	Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)

//=================================================================================================================

// 1.Задание входных данных:

int[,] arrayCoordinates = new int[60, 6] { 
//  {ax, ay, bx, by, x, y}
	{-8, -1, -1, 1, -6, -5},
	{-3, -2, -2, 6, -9, -7}, 
	{-4, -5, -5, 3, -4, -3}, 
	{-5, -2, -2, 4, -6, -1}, 
	{-4, -7, -7, 8, -1, -6}, 
	{-3, -4, -4, 2, -8, -6}, 
	{-4, -5, -5, 2, 1, 9}, 
	{-7, -2, -2, 7, 7, 3}, 
	{-7, -5, -5, 8, 4, 8}, 
	{-2, 3, 3, -1, 7, 1}, 
	{-7, -6, -6, 5, 3, 9}, 
	{-3, -8, -8, 3, -2, 8}, 
	{-3, -8, -8, 1, 2, 5}, 
	{-6, -2, -2, 2, 1, 8}, 
	{-6, -7, -7, 4, 3, 4}, 
	{-6, -7, -7, 2, 1, 4}, 
	{-5, -6, -6, 3, 8, 1}, 
	{-7, -4, -4, 5, 4, 2}, 
	{-8, -2, -2, 6, 4, 5}, 
	{-9, -4, -4, 6, 1, 4}, 
	{-1, -9, -9, 1, 6, 4}, 
	{-6, -5, -5, 4, 7, 3}, 
	{-3, 3, 3, -2, 2, 4}, 
	{-9, -9, -9, 9, 2, 3}, 
	{-9, -3, -3, 3, 2, 6}, 
	{-9, -2, -2, 3, 7, 2}, 
	{-4, -9, -9, 2, 6, -1}, 
	{-8, -6, -6, 7, 2, 3}, 
	{-1, -8, -8, 6, -2, 7}, 
	{-8, -2, -2, 7, 3, 5}, 
	{-6, -5, -5, 3, -8, -1}, 
	{-9, -7, -7, 3, -3, -2}, 
	{-4, -3, -3, 1, -4, -5}, 
	{-6, -1, -1, 2, -5, -2}, 
	{-1, -6, -6, 1, -4, -7}, 
	{-8, -6, -6, 6, -3, -4}, 
	{1, 9, 9, -3, -4, -5}, 
	{7, 3, 3, -8, -7, -2}, 
	{4, 8, 8, -5, -7, -5}, 
	{7, 1, 1, -2, -2, 3}, 
	{3, 9, 9, -5, -7, -6}, 
	{-2, 8, 8, 4, -3, -8}, 
	{2, 5, 5, -4, -3, -8}, 
	{1, 8, 8, -2, -6, -2}, 
	{3, 4, 4, -6, -6, -7}, 
	{1, 4, 4, -4, -6, -7}, 
	{8, 1, 1, -6, -5, -6}, 
	{4, 2, 2, -5, -7, -4}, 
	{4, 5, 5, -5, -8, -2}, 
	{1, 4, 4, -7, -9, -4}, 
	{6, 4, 4, -8, -1, -9}, 
	{7, 3, 3, -5, -6, -5}, 
	{2, 4, 4, -2, -3, 3}, 
	{2, 3, 3, -7, -9, -9}, 
	{2, 6, 6, -5, -9, -3}, 
	{7, 2, 2, -9, -9, -2}, 
	{6, -1, -1, -4, -4, -9}, 
	{2, 3, 3, -5, -8, -6}, 
	{-2, 7, 7, -9, -1, -8}, 
	{3, 5, 5, -4, -8, -2}
};

//=================================================================================================================

// 2. Разработка метода, который будет выдавать расстояние от точки до каждой крайней точки образующей отрезок

// Решение:

double[,] GetArrayDistanceFromPointEachExtremePointFormingSegment(int[,] array){
	//4-ый столбец зарезервирован для кратчайщего расстояния
	double[,] newArray = new double[array.GetLength(0), 4];
	for(int i = 0; i < array.GetLength(0); i++){
		newArray[i, 0] = Math.Sqrt(Math.Pow((array[i,0] - array[i,4]), 2) + Math.Pow((array[i,1] - array[i,5]), 2));
		newArray[i, 1] = Math.Sqrt(Math.Pow((array[i,2] - array[i,4]), 2) + Math.Pow((array[i,3] - array[i,5]), 2));
		newArray[i, 2] = Math.Sqrt(Math.Pow((array[i,0] - array[i,2]), 2) + Math.Pow((array[i,1] - array[i,3]), 2));
		
		if((Math.Pow(array[i,0], 2) > Math.Pow(array[i,1], 2) + Math.Pow(array[i,2], 2)) || (Math.Pow(array[i,1], 2) > Math.Pow(array[i,0], 2) + Math.Pow(array[i,2], 2))){
			if(newArray[i, 0] < newArray[i, 1]){
				newArray[i, 3] = newArray[i, 0];
			} else {
				newArray[i, 3] = newArray[i, 1];
			}
		} else {
			double p = (newArray[i, 0] + newArray[i, 1] + newArray[i, 2]) / 2;
			//Нахождение площади треугольника по формуле Герона
			double s = Math.Sqrt(p * (p - newArray[i, 0]) * (p - newArray[i, 1]) * (p - newArray[i, 2]));
			newArray[i, 3] = 2 * s / newArray[i, 2];
		}
	}
	return newArray;
}

//=================================================================================================================

// 3. Разработка метода, который будет выводить данные

// Решение:

void PrintArray(double[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        Console.WriteLine($"Номер теста: {i + 1}");
		Console.WriteLine($"Длина до 1 точки: {Math.Round(array[i,0], 3)}");
		Console.WriteLine($"Длина до 2 точки: {Math.Round(array[i,1], 3)}");
		Console.WriteLine($"Длина отрезка: {Math.Round(array[i,2], 3)}");
		Console.WriteLine($"Кратчайшее расстояние от точки до отрезка: {Math.Round(array[i,3], 3)}");
		//Console.WriteLine($"Кратчайшее расстояние от точки до отрезка: {CalculatingShortestDistance(array, )}");
		Console.WriteLine();
    }
}

//=================================================================================================================

// Тесты:

PrintArray(GetArrayDistanceFromPointEachExtremePointFormingSegment(arrayCoordinates));
