export interface HealthCheck {
  id: number
  status: string
  onStateFrom: string
  lastExecuted: string
  uri: string
  name: string
  discoveryService?: any
  entries: Entry[]
  history: any[]
}

interface Entry {
  id: number
  name: string
  status: string
  description: string
  duration: string
  tags?: any
}
