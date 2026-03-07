# How to Export UML Diagrams as Images

## Files Created
| File | Pattern |
|---|---|
| `01_Singleton.puml` | Singleton (DatabaseManager + RoomSubject) |
| `02_Factory.puml` | Factory Method (Room hierarchy + RoomFactory) |
| `03_Strategy.puml` | Strategy (IPaymentStrategy + Cash/CreditCard + Context) |
| `04_Observer.puml` | Observer (IObserver + RoomSubject + HousekeepingObserver) |
| `05_Repository.puml` | Repository (IRepository<T> + 7 repos + DatabaseManager) |
| `06_Facade.puml` | Facade (BookingFacade + UI + DAL) |

---

## Option A — Online (Fastest, no install)

1. Open https://www.plantuml.com/plantuml/uml/
2. Delete the sample text in the editor
3. Open any `.puml` file in Notepad and copy all the text
4. Paste into the editor — the diagram renders instantly on the right
5. Click **PNG** or **SVG** button above the diagram to download

---

## Option B — VS Code Extension (Recommended for all 6 at once)

1. Install **VS Code** if not already installed
2. Install the **PlantUML** extension (publisher: jebbs)
3. Open any `.puml` file in VS Code
4. Press `Alt+D` to preview the diagram
5. Right-click the preview → **Export Current Diagram** → choose PNG
6. To export ALL diagrams at once: open Command Palette (`Ctrl+Shift+P`) → **PlantUML: Export Workspace Diagrams**

---

## Arrow Types Used (Reference)

| Syntax | Meaning | Arrow |
|---|---|---|
| `A <\|-- B` | Inheritance (B extends A) | Solid line, hollow triangle |
| `A <\|.. B` | Interface implementation | Dashed line, hollow triangle |
| `A --> B` | Association / dependency | Solid arrow |
| `A ..> B` | Dependency (weaker) | Dashed arrow |
| `A o--> B` | Aggregation | Solid arrow with diamond |

---

## About the Visual Studio `.cd` Class Designer (for reference)

The `.cd` designer in Visual Studio draws relationships **automatically from code** (inheritance and interface implementation appear on their own when you drag classes in). To add manual arrows:
- View → Toolbox → find **Class Designer** section
- Drag **Association**, **Dependency**, or **Inheritance** lines between shapes on the canvas

However, Visual Studio Class Diagrams cannot be easily exported as high-quality images for slides — PlantUML (above) is much better for this purpose.
