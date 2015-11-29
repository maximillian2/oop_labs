// Вариант №11

#include <iostream>
#include <cmath>

using namespace std;

class Rectangle {
	private:
		int _x1, _y1, _x2, _y2, _x3, _y3, _x4, _y4;
		float perimeter;
		float square;
		float first, second, third, fourth;
		
	public:
		Rectangle();
		Rectangle(int, int, int, int, int, int, int, int);
		~Rectangle();

	    friend ostream& operator<<(ostream& os, const Rectangle& dt);

		void setXs(int, int, int, int);
		void setYs(int, int, int, int);
		void setSides();
		
		float getPerimeter();
		float getSquare();
		float getFirstSide();
		float getSecondSide();
		float getThirdSide();
		float getFourthSide();

		void drawRectangle(float, float);
};

Rectangle::Rectangle() {}

Rectangle::Rectangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
{

	setXs(x1, x2, x3, x4);
	setYs(y1, y2, y3, y4);

	cout << "Coordinates successfully set." << endl;

	setSides();

	cout << "Sides successfully set." << endl;
}

ostream& operator<<(ostream& os, Rectangle& rect)
{
	os << "First side: " << rect.getFirstSide() << '\n';
	os << "Second side: " << rect.getSecondSide() << '\n';
	os << "Third side: " << rect.getThirdSide() << '\n';
	os << "Fourth side: " << rect.getFourthSide() << '\n';
	return os;
}

void Rectangle::setSides()
{
	// first - xy1, xy2
	first = sqrt(pow((_x2-_x1), 2) + pow((_y2-_y1), 2));	
	// second - xy2, xy3	
	second = sqrt(pow((_x3-_x2), 2) + pow((_y3-_y2), 2));	
	// third - xy3, xy4
	third = sqrt(pow((_x4-_x3), 2) + pow((_y4-_y3), 2));	
	// fourth - xy4, xy1
	fourth = sqrt(pow((_x1-_x4), 2) + pow((_y1-_y4), 2));	
}

void Rectangle::setXs(int x1, int x2, int x3, int x4)
{
	_x1 = x1;
	_x2 = x2;
	_x3 = x3;
	_x4 = x4;	
}

void Rectangle::setYs(int y1, int y2, int y3, int y4)
{
	_y1 = y1;
	_y2 = y2;
	_y3 = y3;
	_y4 = y4;	
}

float Rectangle::getFirstSide() 	{ return first; }
float Rectangle::getSecondSide() 	{ return second; }
float Rectangle::getThirdSide() 	{ return third; }
float Rectangle::getFourthSide()	{ return fourth; }
float Rectangle::getPerimeter() 	{ return first+second+third+fourth; }
float Rectangle::getSquare() 		{ return first*second; }


void Rectangle::drawRectangle(float side1, float side2)
{
	for(int i = 0; i < std::round(side1); i++)
	{
		for(int j = 0; j < std::round(side2); j++)
		{
			cout << "/";
		}
		cout << endl;
	}
}

int main()
{	
	float x1, y1, x2, y2, x3, y3, x4, y4; 
	cout << "Enter digits (x1, y1, x2, y2, x3, y3, x4, y4): " << endl;
	cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3 >> x4 >> y4;
	
	Rectangle *rectangle = new Rectangle;
	rectangle->setXs(x1, x2, x3, x4);
	rectangle->setYs(y1, y2, y3, y4);
	rectangle->setSides();
	
	cout << *rectangle << endl;
	cout << "Perimeter:" << rectangle->getPerimeter() << endl;
	cout << "Square: " <<  rectangle->getSquare() << endl;
	cout << "Draw me!" << endl;
	rectangle->drawRectangle(rectangle->getFirstSide(), rectangle->	getSecondSide());
	return 0; 	
}
