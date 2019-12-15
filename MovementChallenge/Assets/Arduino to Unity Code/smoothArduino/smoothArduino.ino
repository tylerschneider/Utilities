const int SW_pin = A3; 
const int P_pin = A2;
const int X_pin = A1; 
const int Y_pin = A0; 
int x_direction;
int y_direction;
int pent;
int jump;

void setup() {
  pinMode(SW_pin, INPUT);
  pinMode(P_pin, INPUT);
  pinMode(X_pin, INPUT);
  pinMode(Y_pin, INPUT);

  Serial.begin(9600);
}
 
void loop() {

  x_direction = (analogRead(X_pin));
  x_direction = map(x_direction, 0, 1023, -1000, 1000);
  Serial.print(String(x_direction) + ",");
  Serial.flush();

  y_direction = (analogRead(Y_pin));
  y_direction = map(y_direction, 0, 1023, -1000, 1000);
  Serial.print(String(y_direction) + ",");
  Serial.flush();

  jump = (analogRead(SW_pin));
  Serial.print(String(jump) + ",");
  Serial.flush();
  
  pent = analogRead(P_pin);
  pent = map(pent, 0, 1023, 0, 1000);
  Serial.println(String(pent));
  Serial.flush();

  delay(10);
}
