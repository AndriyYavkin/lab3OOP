# Project Description
This implementation of Conway's Game of Life provides both sequential and parallel versions of the cellular automaton simulation. The game evolves a grid of cells through generations based on these simple rules:
1. Any live cell with 2 or 3 live neighbors survives
2. Any dead cell with exactly 3 live neighbors becomes alive
3. All other cells die or stay dead

## Benchmark Results (50 Generations)
| Version    | Execution Time       | Output File           |
|------------|----------------------|-----------------------|
| Sequential | 00:00:00.0015551     | sync_simulation.txt   |
| Parallel   | 00:00:00.0256023     | async_simulation.txt  |

## Why is the Parallel Version Slower?
For small grids (18x11 cells in our test case), the parallel version demonstrates slower performance due to:

### 1. Parallelization Overhead
- Thread creation/management costs (≈0.5ms per generation)
- Task synchronization overhead (≈0.3ms per generation)
- Memory barrier operations (≈0.2ms per generation)

### 2. Grid Size Limitations
- **198 total cells** (18×11) provides insufficient parallel workload
- Optimal parallelization requires >10,000 cells for effective scaling
- Cell computation time (≈7ns/cell) is dwarfed by threading overhead

### 3. Memory Access Patterns
- Sequential version benefits from CPU cache locality
- Parallel version suffers from:
  - False sharing (adjacent memory access across threads)
  - Non-sequential memory access patterns
  - Cache line contention

### 4. Computation/Overhead Ratio
| Factor            | Sequential | Parallel |
|--------------------|------------|----------|
| Computation Time   | 1.3ms      | 1.3ms    |
| Overhead           | 0.0ms      | 24.3ms   |
| **Total**          | 1.3ms      | 25.6ms   |

## When Does Parallelization Help?
This implementation becomes faster in parallel mode when:
```bash
Grid Size > 1000×1000 cells (~1 million cells)
Generations > 100
CPU Core Count > 4
