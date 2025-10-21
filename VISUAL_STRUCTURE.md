# Visual Structure Documentation

## Application Layout

```
┌──────────────────────────────────────────────────────────────────┐
│  MainWindow (900x600)                                            │
│  Background: Dark Brown Gradient                                 │
│  ┌────────────────────────────────────────────────────────────┐ │
│  │ Snowflakes Layer (Canvas - Z-index: 10)                    │ │
│  │   ❄ ❄  ❄   ❄   ❄  ❄   ❄  ❄   ❄                         │ │
│  │                                                              │ │
│  │  ┌──────────────────────────────────────────────────────┐  │ │
│  │  │ Content Border (Parchment #FFF8E7)                   │  │ │
│  │  │  Drop Shadow Effect                                   │  │ │
│  │  │  ┌────────────────────────────────────────────────┐  │  │ │
│  │  │  │ Decorative Border (Red #C41E3A)               │  │  │ │
│  │  │  │                                                │  │  │ │
│  │  │  │  ╔══════════════════════════════════════════╗ │  │  │ │
│  │  │  │  ║   A Christmas Message                    ║ │  │  │ │
│  │  │  │  ║   (Title - Segoe Script, 32pt)          ║ │  │  │ │
│  │  │  │  ╚══════════════════════════════════════════╝ │  │  │ │
│  │  │  │                                                │  │  │ │
│  │  │  │  ┌────────────────────────────────────────┐  │  │  │ │
│  │  │  │  │ Poem Canvas                             │  │  │ │ │
│  │  │  │  │                                          │  │  │ │ │
│  │  │  │  │  Missing you this Christmas time,       │  │  │ │ │
│  │  │  │  │  While on vacation, far away,           │  │  │ │ │
│  │  │  │  │  Though miles apart...                   │  │  │ │ │
│  │  │  │  │                                       🪶 │  │  │ │ │
│  │  │  │  │  (Text + Animated Quill)                │  │  │ │ │
│  │  │  │  │                                          │  │  │ │ │
│  │  │  │  └────────────────────────────────────────┘  │  │  │ │
│  │  │  │                                                │  │  │ │
│  │  │  │  🎄 Holly Berries (Decorative)             🎄 │  │  │ │
│  │  │  └────────────────────────────────────────────────┘  │  │ │
│  │  └──────────────────────────────────────────────────────┘  │ │
│  └────────────────────────────────────────────────────────────┘ │
└──────────────────────────────────────────────────────────────────┘
```

## Quill Pen Component Structure

```
QuillCanvas (Composite Element)
    │
    ├─ QuillFeather (Path - Red #C41E3A)
    │   │
    │   ├─ Bezier Curve 1: Feather Top (20,0 → 20,15)
    │   └─ Bezier Curve 2: Feather Shaft (20,0 → 18,20 → 22,20)
    │
    ├─ QuillTip (Polygon - Gold #FFD700)
    │   │
    │   └─ Triangle Points: (18,20), (22,20), (20,28)
    │
    └─ InkSparkle (Ellipse - Blue #4169E1)
        │
        └─ Position: (16,26) - At tip of quill
```

## Animation Timeline

```
Time (seconds)
│
0s  ├─ Window Opens
    │  └─ Snowflakes begin falling
    │
1s  ├─ Quill Entry Animation Starts
    │  └─ Quill descends from top (-100 → 0)
    │     Duration: 1.5s
    │     Easing: QuadraticEase (EaseOut)
    │
1s  ├─ Typing Animation Starts
    │  └─ Timer begins (50ms intervals)
    │
~   ├─ Writing Phase (Duration varies)
    │  ├─ Character appears every 50ms
    │  ├─ Quill moves to follow cursor
    │  ├─ Ink sparkle effect on each char
    │  └─ Floating animation continues
    │
End ├─ Writing Complete
    │  └─ Quill Exit Animation
    │     Quill ascends upward (0 → -200)
    │     Duration: 2s
    │     Easing: QuadraticEase (EaseIn)
    │
∞   └─ Snowflakes continue indefinitely
```

## Animation Loops

### Continuous Animations (Running Throughout)

1. **Quill Floating**
   ```
   Y Position: 0 ←→ -5 (1.5s cycles)
   Rotation:   -2° ←→ 2° (2s cycles)
   ```

2. **Snowfall**
   ```
   Each snowflake:
   - Falls from top to bottom (5-15s duration)
   - Sways left/right (±30 pixels)
   - Random starting positions
   - Repeats infinitely
   ```

3. **Ink Sparkle** (During typing only)
   ```
   Every 50ms:
   - Scale: 1.5 → 0.5 → 1.5 (200ms)
   - Opacity: 1.0 → 0.3 → 1.0 (200ms)
   ```

## Color Palette

```
Christmas Theme Colors:

Background Gradient:
  ┌─────────────┐
  │  #2C1810    │ Dark Brown (Top)
  │     ↓       │
  │  #4A2C1F    │ Medium Brown (Middle)
  │     ↓       │
  │  #2C1810    │ Dark Brown (Bottom)
  └─────────────┘

Content Colors:
  ⬜ #FFF8E7 - Parchment (Main background)
  🟥 #C41E3A - Christmas Red (Borders, Quill)
  🟫 #8B4513 - Saddle Brown (Frame)
  🟨 #FFD700 - Gold (Quill tip)
  🟦 #4169E1 - Royal Blue (Ink sparkle)
  🟩 #2C1810 - Dark Brown (Text)
  ⬜ #FFFFFF - White (Snowflakes)
```

## Element Hierarchy

```
Window
 └─ Grid (Background)
     ├─ SnowflakeCanvas (Layer 1 - Z-index: 10)
     │   └─ Ellipse × 30 (Animated snowflakes)
     │
     └─ Border (Layer 2 - Main Content)
         └─ Grid (Content Container)
             ├─ Border (Decorative Frame)
             │   └─ Grid (Inner Content)
             │       ├─ TextBlock (Title)
             │       └─ Canvas (Poem Canvas)
             │           ├─ TextBlock (Poem Text)
             │           └─ Canvas (Quill Canvas)
             │               ├─ Path (Feather)
             │               ├─ Polygon (Tip)
             │               └─ Ellipse (Sparkle)
             │
             └─ Canvas (Decorations)
                 ├─ Ellipse × 3 (Top-left holly)
                 └─ Ellipse × 3 (Top-right holly)
```

## Transform Groups

### QuillCanvas Transform Structure
```
TransformGroup
 ├─ TranslateTransform
 │   ├─ X: (follows text position)
 │   └─ Y: (floating animation + entry/exit)
 │
 └─ RotateTransform
     ├─ Angle: -2° to 2° (gentle rotation)
     ├─ CenterX: 20
     └─ CenterY: 15
```

## Text Rendering

The poem text uses FormattedText for accurate positioning:
```
Font: Segoe Script
Size: 22pt
Line Height: 35pt
Color: #2C1810 (Dark Brown)
Width: 700px (Wrapping enabled)
```

This ensures the quill can accurately track the writing position based on actual rendered text dimensions.
